using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementModels
{
    public class Room
    {
        public Room()
        {
            Id = 0;
            RoomType = string.Empty;
            Features = string.Empty;
            OccupancyCapacity = 0;
            NightlyRate = 0;
        }

        public Room(int id, string roomType, string features, int occupancyCapacity, double nightlyRate)
        {
            Id = id;
            RoomType = roomType;
            Features = features;
            OccupancyCapacity = occupancyCapacity;
            NightlyRate = nightlyRate;
        }

        public int Id { get; set; }
        public string RoomType {  get; set; }
        public string Features { get; set; }
        public int OccupancyCapacity { get; set; }
        public double NightlyRate { get; set; }

        public override string ToString()
        {
            return RoomType + " " + Features + " " + OccupancyCapacity + " " + NightlyRate ;
        }
    }
}
