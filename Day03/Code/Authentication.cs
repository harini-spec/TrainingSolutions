// Create an application that will take username and password from user. Check if username is "ABC" and passwod is "123". 
// Print error message if username or password is wrong. Allow user 3 attemts.
// After 3rd attempt if user enters invalid credentials then print msg to intimate user that he/she has exceeded the number of attempts and stop

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class Qn5
    {
        static string GetInput(String inp)
        {
            Console.WriteLine($"Enter {inp}:");
            return Console.ReadLine() ?? "Null";
        }

        static void Authentication()
        {
            int count = 0;
            while (count < 3)
            {
                string username = GetInput("username");
                string password = GetInput("password");
                if (!String.Equals(username, "Null") &&  !String.Equals(password,"Null"))
                    if(String.Equals(username, "ABC") && String.Equals(password, "123"))
                    {
                        Console.WriteLine($"Welcome, {username}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong username and password combination");
                        count++;
                    }
                else { Console.WriteLine("Null value is entered"); break; }
            }
            if (count == 3)
            {
                Console.WriteLine("You have exceeded the Maximum number of attempts");
            }
        }

        static void Main(string[] args)
        {
            Authentication();
        }
    }
}
