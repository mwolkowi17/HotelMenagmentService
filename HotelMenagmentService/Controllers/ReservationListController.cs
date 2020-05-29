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
    public class ReservationListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReservationListController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var singlereservation = from n in _context.Reserevations
                                    select n;
            var reservationVM = new HotelViewModel
            {
                ReservationList = singlereservation.ToList()
            };
            return View(reservationVM);
        }

        public IActionResult AddReservation(int idroom, int idguest, DateTime checkin, DateTime checkout)
        {
            if (ModelState.IsValid) { 
            Room RoomToRent = (from Room item in _context.Rooms
                               where item.RoomID == idroom
                               select item).SingleOrDefault();

            Guest GuestToRent = (from Guest item in _context.Guests
                                 where item.GuestID == idguest
                                 select item).SingleOrDefault();
            RoomToRent.is_ocuppied = true;

            Reservation NewReservation = new Reservation();
            NewReservation.status = 0;
            NewReservation.GuestID = GuestToRent.GuestID;
            NewReservation.GuestName = (GuestToRent.name + " " + GuestToRent.surname);
            NewReservation.RoomID = RoomToRent.RoomID;
            NewReservation.check_in = checkin;
            NewReservation.check_out = checkout;
            
            _context.Reserevations.Add(NewReservation);
            _context.SaveChanges();
            }
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationText = "Please enter correct check-in and check-out value!";
            }

            var singlereservation = from n in _context.Reserevations
                                    select n;
            var reservationVM = new HotelViewModel
            {
                ReservationList = singlereservation.ToList()
            };
            return View(reservationVM);
        }
    }
}
