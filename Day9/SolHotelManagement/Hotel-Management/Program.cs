using HotelManagementBL;
using HotelManagementModels;
using System;
using System.ComponentModel.Design;
using System.Runtime.Serialization.Json;

namespace Hotel_Management
{
    public class Program
    {

        public void AddRoom(IRoomService roomBL)
        {
            try
            {
                Room room = new Room();
                Console.WriteLine("Enter Room's type:");
                room.RoomType = Console.ReadLine();
                Console.WriteLine("Enter Room's Occupation Capacity:");
                room.OccupancyCapacity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Room's features:");
                room.Features = Console.ReadLine();
                Console.WriteLine("Enter Room's Nightly rate:");
                room.NightlyRate = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(roomBL.AddRoom(room));
            }
            catch(RoomAlreadyExistsException raee)
            {
                Console.WriteLine(raee.Message);
            }
        }

        public bool CheckAvailability(Reservation reservation, IRoomService roomBL)
        {
            if(roomBL.CheckRoomAvailability(reservation.CheckInDate, reservation.CheckOutDate, reservation.Room))
                return true;
            return false;
        }

        public void MakeReservation(IRoomService roomBL, IReservationService reservationBL, ICustomerService customerBL)
        {
            try
            {
                Reservation reservation = new Reservation();
                Console.WriteLine("Enter Customer ID:");
                reservation.Customer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Room ID:");
                reservation.Room = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the occupancy quantity:");
                reservation.OccupancyCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your room preference if any:");
                reservation.Preferences = Console.ReadLine();
                Console.WriteLine("Enter the check-in date:");
                reservation.CheckInDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter the check-out date:");
                reservation.CheckOutDate = Convert.ToDateTime(Console.ReadLine());

                if (CheckAvailability(reservation, roomBL))
                {
                    int id = reservationBL.AddReservation(reservation, reservation.Room);
                    Console.WriteLine("Reservation successfully added!");
                    customerBL.AddReservation(reservationBL.GetReservationByID(id));
                    roomBL.AddReservation(reservationBL.GetReservationByID(id));
                    PrintReservationDetails(id, reservationBL, roomBL, customerBL);
                }
                else
                    Console.WriteLine("Room already booked");
            }
            catch(RoomDoesNotExistException rdnee)
            {
                Console.WriteLine(rdnee.Message);
            }
            catch (ReservationAlreadyExistsException raee)
            {
                Console.WriteLine(raee.Message);
            }
        }

        public void PrintReservationDetails(int id, IReservationService reservationBL, IRoomService roomBL, ICustomerService customerBL)
        {
            Console.WriteLine("--------------------------------------------");
            Reservation reservation = reservationBL.GetReservationByID(id);
            Customer customer = customerBL.GetCustomerByID(reservation.Customer);
            Console.WriteLine(reservation.Room);
            Room room = roomBL.GetRoomByID(reservation.Room);
            Console.WriteLine("Customer Name: " + customer.Name);
            Console.WriteLine("Customer Mobile: " + customer.PhoneNo);
            Console.WriteLine("Room Type: " + room.RoomType);
            Console.WriteLine("Room features: " + room.Features);
            Console.WriteLine("Check in date: " + reservation.CheckInDate);
            Console.WriteLine("Check out date: " + reservation.CheckOutDate);
            Console.WriteLine("Occupancy count: " + reservation.OccupancyCount);
            Console.WriteLine("Total cost: " + reservation.TotalCost);
            Console.WriteLine("Cancellation Policy: " + reservation.CancellationPolicy);
            Console.WriteLine("--------------------------------------------");
        }

        public void CreateCustomer(ICustomerService customerBL)
        {
            try
            {
                Customer customer = new Customer();
                Console.WriteLine("Enter your name:");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Enter your mobile number:");
                customer.PhoneNo = Console.ReadLine();
                int id = customerBL.AddCustomer(customer);
                Console.WriteLine("Customer account created successfully. Your ID is " + id);
            }
            catch (CustomerAlreadyExistsException caee)
            {
                Console.WriteLine(caee.Message);
            }
        }

        public void DisplayRooms(IRoomService roomBL)
        {
            List<Room> rooms = roomBL.GetAllRooms();
            Console.WriteLine("ID \t Room Type \t Features \t Max Occupancy \t Nightly cost");
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.Id + "   \t" + room.ToString());
            }
        }

        public void ModifyReservation(IReservationService reservationBL, IRoomService roomBL, ICustomerService customerBL)
        {
            try
            {
                Console.WriteLine("Enter your reservation ID");
                int id = Convert.ToInt32(Console.ReadLine());
                Reservation reservation = reservationBL.GetReservationByID(id);
                Console.WriteLine("Check in date: " + reservation.CheckInDate);
                Console.WriteLine("Check out date: " + reservation.CheckOutDate);
                reservationBL.ModifyBooking(reservation);
                Console.WriteLine("Modified successfully");
                PrintReservationDetails(reservation.Id, reservationBL, roomBL, customerBL);
            }
            catch (ReservationDoesNotExistException rdnee)
            {
                Console.WriteLine(rdnee.Message);
            }
        }

        public void CancelReservation(IReservationService reservationBL)
        {
            try
            {
                Console.WriteLine("Enter your reservation ID");
                int id = Convert.ToInt32(Console.ReadLine());
                reservationBL.CancelBooking(id);
                Console.WriteLine("Reservation deleted successfully");
            }
            catch(ReservationDoesNotExistException rdnee)
            {
                Console.WriteLine(rdnee.Message);
            }

        }

        public void DisplayMenu()
        {
            Program program = new Program();
            IRoomService roomBL = new RoomBL();
            ICustomerService customerBL = new CustomerBL();
            IReservationService reservationBL = new ReservationBL();
            string choice;
            do
            {
                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Display Rooms");
                Console.WriteLine("3. Create customer account");
                Console.WriteLine("4. Make reservation");
                Console.WriteLine("5. Modify reservation");
                Console.WriteLine("6. Cancel reservation");
                Console.WriteLine("0 to exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        program.AddRoom(roomBL);
                        break;
                    case "2":
                        program.DisplayRooms(roomBL);
                        break;
                    case "3":
                        program.CreateCustomer(customerBL);
                        break;
                    case "4":
                        program.MakeReservation(roomBL, reservationBL, customerBL);
                        break;
                    case "5":
                        program.ModifyReservation(reservationBL, roomBL, customerBL);
                        break;
                    case "6":
                        program.CancelReservation(reservationBL);
                        break;
                }

            } while (choice != "0");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.DisplayMenu();
        }
    }
}
