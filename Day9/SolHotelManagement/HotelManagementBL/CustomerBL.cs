using HotelManagementDAL;
using HotelManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBL
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _CustomerRepository;
        public CustomerBL()
        {
            _CustomerRepository = new CustomerRepository();
        }

        public int AddCustomer(Customer customer)
        {
            var result = _CustomerRepository.Add(customer);
            if (result != null)
                return result.Id;
            throw new CustomerAlreadyExistsException();
        }

        public Customer GetCustomerByID(int customerID)
        {
            return _CustomerRepository.Get(customerID);
        }

        public void AddReservation(Reservation reservation)
        {
            Customer customer = GetCustomerByID(reservation.Customer);
            customer.Reservations.Add(reservation.Id);
            _CustomerRepository.Update(customer);
        }

        public List<int> GetReservationList(int id)
        {
            Customer customer = _CustomerRepository.Get(id);
            List<int> reservations = customer.Reservations;
            return reservations;
        }
    }
}
