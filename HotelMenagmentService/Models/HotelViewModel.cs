using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentService.Models
{
    public class HotelViewModel
    {
        public List<Room> RoomList { get; set; }
        public List<Guest> GuestList { get; set; }
        public List<Reservation> ReservationList { get; set; }
    }
}
