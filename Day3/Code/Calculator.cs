// Create an application that take 2 numbers and find its sum, product and divide the first by second, also subtract the second from the first. 
// Include another method to find the remainder when the first number is divided by second

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class Qn1
    {
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        static double Remainder(double num1, double num2)
        {
            return num1 % num2;
        }

        static double GetNumber()
        {
            Console.WriteLine("Enter a number:");
            double num;
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid Entry. Please enter a Number");
            }
            return num;
        }

        static void PrintResult(double result, String opr)
        { 
            Console.WriteLine($"{opr} = {result}");
        }

        static void Calculate()
        {
            double num1 = GetNumber();
            double num2 = GetNumber();
            double sum = Add(num1, num2);
            PrintResult(sum, "Sum");
            double prod = Multiply(num1, num2);
            PrintResult(prod, "Product");
            double diff = Subtract(num1, num2);
            PrintResult(diff, "Difference");
            double quot = Divide(num1, num2);
            PrintResult(quot, "Quotient");
            double rem = Remainder(num1, num2);
            PrintResult(rem, "Remainder");
        }

        static void Main(string[] args)
        {
           Calculate();
        }
    }
}
