using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HotelManagementModels
{
    public class Reservation
    {
        public Reservation()
        {
            Id = 0;
            Customer = 0;
            Room = 0;
            CheckInDate = DateTime.Now;
            CheckOutDate = DateTime.Now;
            OccupancyCount = 0;
            TotalCost = 0;
            CancellationPolicy = string.Empty;
        }

        public Reservation(int id, int customer, int room, DateTime checkInDate, DateTime checkOutDate, int occupancyCount, double totalCost, string cancellationPolicy)
        {
            Id = id;
            Customer = customer;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            OccupancyCount = occupancyCount;
            TotalCost = totalCost;
            CancellationPolicy = cancellationPolicy;
        }

        public int Id { get; set; }
        public int Customer { get; set; }
        public int Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int OccupancyCount { get; set; }
        public double TotalCost { get; set; }
        public string CancellationPolicy { get; set; }

    }
}


