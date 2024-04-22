using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementModels
{
    internal class Customer
    {
        public Customer() 
        {
            Id = 0;
            Name = string.Empty;
            PhoneNo = string.Empty;
            OccupancyCount = 0;
            CheckInDate = DateTime.Now;
            CheckOutDate = DateTime.Now;
            Preferences = string.Empty;
        }
        public Customer(int id, string name, string phoneNo, int occupancyCount, DateTime checkInDate, DateTime checkOutDate, string preferences)
        {
            Id = id;
            Name = name;
            PhoneNo = phoneNo;
            OccupancyCount = occupancyCount;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Preferences = preferences;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public int OccupancyCount { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Preferences { get; set; }
    }
}
