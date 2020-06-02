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
    public class ReservationHistoryListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReservationHistoryListController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var singlereservationHistory = from n in _context.ReservationHistoryItems
                                           select n;
            var reservationHistoryVM = new HotelViewModel
            {
                ReservationHistoryList = singlereservationHistory.ToList()
            };
            return View(reservationHistoryVM);
        }
    }
}
