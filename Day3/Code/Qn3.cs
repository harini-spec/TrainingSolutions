//Find the avearage of all the numbers that are divisible by 7. Take input until the user enters a negative number

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class Qn3
    {
        static void PrintResult(float avg, String opr)
        {
            if(avg>0)
                Console.WriteLine($"{opr} of numbers divisible by 7 = {avg}");
        }
        static void FindAverage()
        {
            Console.WriteLine("Enter a number. Enter a -ve number to stop");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Enter a valid number");
            float avg;
            int sum = 0, count = 0;
            while(num >= 0)
            {
                if (num % 7 == 0 && num!=0)
                {
                    sum += num;
                    count++;
                }
                while (!int.TryParse(Console.ReadLine(), out num))
                    Console.WriteLine("Enter a valid number");
            }
            avg = (float)sum / (float)count;
            PrintResult(avg, "Average");
        }

        static void Main(string[] args)
        {
           FindAverage();
        }
    }
}
