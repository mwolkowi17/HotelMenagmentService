using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentService.Models
{
    public class Guest
    {
      

       

        public int GuestID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime member_since { get; set; } 
        
        public Guest(string nameuser, string surnameuser)
        {
            name = nameuser;
            surname = surnameuser;

            member_since = DateTime.Today;
        }
        public Guest()
        {

        }
    }
}
