using HotelManagementBL;
using HotelManagementModels;
using System.ComponentModel.Design;
using System.Runtime.Serialization.Json;

namespace Hotel_Management
{
    public class Program
    {
        public void AddRoom(RoomBL roomBL)
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

        public void CreateCustomer()
        {
            Room room = roomBL.GetRoomByID(1);
            Console.WriteLine(room.ToString());
        }

        public void DisplayMenu()
        {
            Program program = new Program();
            RoomBL roomBL = new RoomBL();
            CustomerBL customerBL = new CustomerBL();
            ReservationBL reservationBL = new ReservationBL();
            string choice;
            do
            {
                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Create Customer Account");
                Console.WriteLine("3. Make reservation");
                Console.WriteLine("4. Modify reservation");
                Console.WriteLine("5. Cancel reservation");
                Console.WriteLine("6. Check availability");
                Console.WriteLine("0 to exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        program.AddRoom(roomBL);
                        break;
                    case "2":
                        program.CreateCustomer();
                        break;
                    case "3":
                        program.MakeReservation();
                        break;
                    case "4":
                        program.ModifyReservation();
                        break;
                    case "5":
                        program.CancelReservation();
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
