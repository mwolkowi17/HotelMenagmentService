﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentService.Models
{
    public enum ResStatus
    {
        active,canceled,deleted
    }
    public class Reservation
    {
        
        public int ReservationID { get; set; }

        [Display(Name = "Checkin Date")]
        [DataType(DataType.Date)]
        
        public DateTime check_in { get; set; }

        [Display(Name = "Checkout Date")]
        [DataType(DataType.Date)]
        
        public DateTime check_out { get; set; }
        public ResStatus status { get; set; }
        public string made_by { get; set; }
        public int GuestID { get; set; }
        public string GuestName { get; set; }
        public int RoomID { get; set; }
    
    }
}
