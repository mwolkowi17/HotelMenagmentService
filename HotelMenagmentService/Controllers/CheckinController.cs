using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            ViewBag.RoomNr = id;
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
            var usertocheckin = from n in _context.Reserevations
                               where n.ReservationID == id
                               select n.GuestName;
            roomtocheckin.First().is_ocuppied = true;
            roomtocheckin.First().Guest = usertocheckin.First();
            _context.SaveChanges();
            //return RedirectToAction(nameof(Index));
            ViewBag.CheckinInformation = "Check-in complete.";
            ViewBag.CheckinData = $"Room nr {roomtocheckin.First().RoomID} has been rented to {usertocheckin.First()}.";
            var roomreservedfortoday = from o in _context.Reserevations
                                       where o.check_in == DateTime.Today
                                       select o;
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

        public IActionResult CheckinRoomAdd(int id, string name, string surname)
        {
            var roomtocheckin = from m in _context.Rooms
                                where m.RoomID == id
                                select m;
            roomtocheckin.First().is_ocuppied = true;
            roomtocheckin.First().Guest = name +" " + surname;
            _context.SaveChanges();
            
            
            ViewBag.CheckinInformation = "Check-in Complete.";
            ViewBag.CheckinData = $"Room nr {id} has been rented to {name} {surname}";
            var roomreservedfortoday = from o in _context.Reserevations
                                       where o.check_in == DateTime.Today
                                       select o;
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
    }
}
