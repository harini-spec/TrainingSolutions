using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace CodeFirstRequestTrackerApp
{
    public static class Globals
    {
        public static Employee LoggedInEmployee { get; set; }
    }

    public class Program
    {
        static async Task Main(string[] args)
        {
            await new MainFrontend().UserMenuDisplay();
        }
    }
}