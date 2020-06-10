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
    public class CheckinController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CheckinController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var roomreservedfortoday = from n in _context.Reserevations
                                       where n.check_in == DateTime.Today
                                       select n;
            var roomnotoccupiedtoday = from m in _context.Rooms
                                       where m.is_ocuppied == false
                                       select m;
            var checkindata = new HotelViewModel
            {
                ReservedForToday = roomreservedfortoday.ToList(),
                RoomList = roomnotoccupiedtoday.ToList()

            };
            return View(checkindata);
        }

        public IActionResult SelectRoom(int id)
        {
            var roomselected = from n in _context.Rooms
                               where n.RoomID == id
                               select n;
            var checkindata = new HotelViewModel
            {
                RoomList = roomselected.ToList()
            };
            return View(checkindata);
        }

        public IActionResult SelectReservation(int id)
        {
            var reservationselected = from n in _context.Reserevations
                                      where n.ReservationID == id
                                      select n;
            var checkindata = new HotelViewModel
            {
                ReservationList = reservationselected.ToList()
            };

            return View(checkindata);
        }
        public IActionResult CheckinAdd(int id)
        {
            var roomnumbertocheckin = from n in _context.Reserevations
                                      where n.ReservationID == id
                                      select n.RoomID;
            var roomtocheckin = from m in _context.Rooms
                                where m.RoomID == roomnumbertocheckin.First()
                                select m;
            roomtocheckin.First().is_ocuppied = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
