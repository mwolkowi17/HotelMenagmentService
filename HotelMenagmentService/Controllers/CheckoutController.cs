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
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var room = from n in _context.Rooms
                       where n.is_ocuppied==true
                       select n;

            var checkoutdata = new HotelViewModel()
            {
                RoomList = room.ToList()
            };
            return View(checkoutdata);
        }
    }
}
