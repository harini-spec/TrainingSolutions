using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementModels
{
    public class Customer
    {
        public Customer() 
        {
            Id = 0;
            Name = string.Empty;
            PhoneNo = string.Empty;
            Preferences = string.Empty;
            Reservations = new List<Reservation>();
        }
        public Customer(int id, string name, string phoneNo, string preferences, Reservation reservation)
        {
            Id = id;
            Name = name;
            PhoneNo = phoneNo;
            Preferences = preferences;
            Reservations.Add(reservation);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Preferences { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
