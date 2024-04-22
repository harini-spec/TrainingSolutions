using HotelManagementModels;

namespace HotelManagementBL
{
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);
        Customer GetCustomerByID(int id);
        void AddReservation(Reservation reservation);
    }
}
