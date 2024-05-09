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
            Reservations = new List<int>();
        }
        public Customer(int id, string name, string phoneNo, int reservation)
        {
            Id = id;
            Name = name;
            PhoneNo = phoneNo;
            Reservations.Add(reservation);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public List<int> Reservations { get; set; }

        public override string ToString()
        {
            return Name + " " + PhoneNo;
        }
    }
}
