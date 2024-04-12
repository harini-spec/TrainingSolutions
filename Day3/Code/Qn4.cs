//Find the length of the given user's name

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    
    internal class Qn4
    {
        static string GetUserName()
        {
            Console.WriteLine("Enter your name:");
            string username = Console.ReadLine()??"Invalid User";
            return username;
        }

        static void PrintNameLength(string username)
        {
            Console.WriteLine(username.Length);
        }
        static void FindNameLength()
        {
            string username = GetUserName();
            if(!String.Equals(username, "Invalid User") && (username.All(char.IsLetter))) {
                PrintNameLength(username);
            }
            else
            {
                Console.WriteLine("Invalid Name Provided");
            }
            
        }

        static void Main(string[] args)
        {
           FindNameLength();
        }
    }
}
