using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentService.Models
{
    public enum RoomType
    {
        singleperson, doubleperson
    }
    public class Room
    {
        public int RoomID { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public bool is_ocuppied { get; set; }
        public bool smoke { get; set; }
        public RoomType nubmerbeds { get; set; }
    }
}
