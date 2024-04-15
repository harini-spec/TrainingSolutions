//create an application that will find the greatest of the given numbers.Take input until the user enters a negative number

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DemoApp
{
    internal class Qn2
    {
        
        static void PrintResult(int max, String msg)
        {
            Console.WriteLine($"{msg} = {max}");
        }

        static void FindMax()
        {
            Console.WriteLine("Enter a number. Enter a -ve number to stop");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Enter a valid number");
            int max;
            if (num >= 0)
                max = num;
            else return;
            while(num >= 0)
            {
                while (!int.TryParse(Console.ReadLine(), out num))
                    Console.WriteLine("Enter a valid number");
                if(num > max)
                {
                    max = num;
                }
            }
            PrintResult(max, "Greatest Number");
        }

        static void Main(string[] args)
        {
           FindMax();
        }
    }
}
