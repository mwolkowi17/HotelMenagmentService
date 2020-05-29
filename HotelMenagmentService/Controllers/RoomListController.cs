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
    public class RoomListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoomListController( ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var singleroom = from m in _context.Rooms
                             select m;
            var roomVM = new HotelViewModel
            {
                RoomList = singleroom.ToList()
            };
            return View(roomVM);
        }
    }
}
