using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelMenagmentService.Data;
using HotelMenagmentService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelMenagmentService.Controllers
{
    public class GuestListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GuestListController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var singleguest = from n in _context.Guests
                              select n;
            var guestVM = new HotelViewModel
            {
                GuestList = singleguest.ToList()
            };
            return View(guestVM);
        }

        public IActionResult AddGuest(string nameuser, string surnameuser)
        {
            if (nameuser != null && surnameuser != null)
            {
                Guest nextguest = new Guest(nameuser, surnameuser);
                
                _context.Guests.Add(nextguest);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteGuest (int id)
        {
            var usertodelete = (from Guest item in _context.Guests
                                where item.GuestID == id
                                select item).FirstOrDefault();
            _context.Guests.Remove(usertodelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
