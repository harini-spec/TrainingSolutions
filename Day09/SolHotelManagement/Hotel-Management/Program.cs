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
                roomBL.AddRoom(room);
            }
            catch(RoomAlreadyExistsException raee)
            {
                Console.WriteLine(raee.Message);
            }
        }

        public bool CheckAvailability(Reservation reservation, IRoomService roomBL)
        {
            if(roomBL.CheckRoomAvailability(reservation.CheckInDate, reservation.CheckOutDate, reservation.Room, roomBL.GetAllRooms()))
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
                Console.WriteLine("Enter the check-in date:");
                reservation.CheckInDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter the check-out date:");
                reservation.CheckOutDate = Convert.ToDateTime(Console.ReadLine());

                if (CheckAvailability(reservation, roomBL))
                {
                    List<Room> rooms = roomBL.GetAllRooms();
                    int id = reservationBL.AddReservation(reservation, rooms);
                    customerBL.AddReservation(reservationBL.GetReservationByID(id));
                    roomBL.AddReservation(id);
                    Console.WriteLine("Reservation successfully added!");
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
            Console.WriteLine("Reservation ID: " + id);
            Console.WriteLine("Room ID: " + reservation.Room);
            Room room = roomBL.GetRoomByID(reservation.Room);
            Console.WriteLine("Customer Name: " + customer.Name);
            Console.WriteLine("Customer Mobile: " + customer.PhoneNo);
            DisplayReservedRoomDetails(reservation, room);
            Console.WriteLine("Cancellation Policy: " + reservation.CancellationPolicy);
            Console.WriteLine("--------------------------------------------");
        }

        public void DisplayReservedRoomDetails(Reservation reservation, Room room)
        {
            Console.WriteLine("Room Type: " + room.RoomType);
            Console.WriteLine("Room features: " + room.Features);
            Console.WriteLine("Check in date: " + reservation.CheckInDate);
            Console.WriteLine("Check out date: " + reservation.CheckOutDate);
            Console.WriteLine("Occupancy count: " + room.OccupancyCapacity);
            Console.WriteLine("Total cost: " + reservation.TotalCost);
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
            Console.WriteLine("ID \t Room Type\tFeatures \t Max Occupancy \t Nightly cost");
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
                Console.WriteLine("Check in date: ");
                reservation.CheckInDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Check out date: ");
                reservation.CheckOutDate = Convert.ToDateTime(Console.ReadLine());
                List<Room> rooms = roomBL.GetAllRooms();
                reservationBL.ModifyBooking(reservation, rooms);
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

        public void DisplayAllReservations(IReservationService reservationBL, IRoomService roomBL, ICustomerService customerBL)
        {
            try
            {
                Console.WriteLine("Enter customer ID");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("--------------------------------------------");
                Customer customer = customerBL.GetCustomerByID(id);

                Console.WriteLine("Customer Name: " + customer.Name);
                Console.WriteLine("Customer Mobile: " + customer.PhoneNo);

                List<int> reservations = customerBL.GetReservationList(id);

                foreach (int reservation in reservations)
                {
                    Reservation UserReservation = reservationBL.GetReservationByID(reservation);
                    Room room = roomBL.GetRoomByID(UserReservation.Room);
                    Console.WriteLine("Room ID: " + UserReservation.Room);

                    DisplayReservedRoomDetails(UserReservation, room);
                }
            }
            catch(NoReservationsExistsException nree)
            {
                Console.WriteLine(nree.Message);
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
                Console.WriteLine("5. Display all user's reservation");
                Console.WriteLine("6. Modify reservation");
                Console.WriteLine("7. Cancel reservation");
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
                        program.DisplayAllReservations(reservationBL, roomBL, customerBL);
                        break;
                    case "6":
                        program.ModifyReservation(reservationBL, roomBL, customerBL);
                        break;
                    case "7":
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
