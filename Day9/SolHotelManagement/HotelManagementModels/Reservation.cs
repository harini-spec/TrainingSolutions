using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HotelManagementModels
{
    internal class Reservation
    {
        public Reservation()
        {
            Id = 0;
            Customer = 0;
            TotalCost = 0;
            CancellationPolicy = string.Empty;
        }

        public Reservation(int id, int customer, double totalCost, string cancellationPolicy)
        {
            Id = id;
            Customer = customer;
            TotalCost = totalCost;
            CancellationPolicy = cancellationPolicy;
        }

        public int Id { get; set; }
        public int Customer { get; set; }
        public double TotalCost { get; set; }
        public string CancellationPolicy { get; set; }

    }
}


