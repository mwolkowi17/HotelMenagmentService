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

        public IActionResult AddReservationHistoryItem( int id)
        {
            Reservation ReservationToArchive = (from Reservation item in _context.Reserevations
                                                where item.ReservationID == id
                                                select item).FirstOrDefault();
            ReservationHistory NewReservationHistoryItem = new ReservationHistory();
            NewReservationHistoryItem.check_in_History = ReservationToArchive.check_in;
            NewReservationHistoryItem.check_out_History = ReservationToArchive.check_out;
            NewReservationHistoryItem.GuestID_History = ReservationToArchive.GuestID;
            NewReservationHistoryItem.GuestName_History = ReservationToArchive.GuestName;
            NewReservationHistoryItem.RoomID_History = ReservationToArchive.RoomID;
            _context.ReservationHistoryItems.Add(NewReservationHistoryItem);
            _context.SaveChanges();
            return View();
        }
    }
}
