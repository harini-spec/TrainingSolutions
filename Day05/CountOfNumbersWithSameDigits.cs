//From a given array find the three digit numbers that have the same number.Example -444

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class SameDigits
    {
        /// <summary>
        /// Gets input from the user in console
        /// </summary>
        /// <returns>User Input as Integer array</returns>
        private int[] getInputFromUser()
        {
            Console.WriteLine("Enter the number of input numbers to be entered:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[n];
            Console.WriteLine($"Enter {n} numbers:");
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            return nums;
        }

        /// <summary>
        /// finds and prints the count of numbers with repeating digits 
        /// </summary>
        private void findRepeatingDigitsCount()
        {
            int[] nums = getInputFromUser();
            int CountOfNumbersWithRepeatingDigits = 0;
            for (int i= 0; i < nums.Length; i++)
            {
                int first, second, third;
                first = nums[i] % 10;
                second = (nums[i] / 10) % 10;
                third = nums[i] / 100;
                if (first == second && second == third && nums[i]>99 && nums[i]<1000)
                    CountOfNumbersWithRepeatingDigits++;
            }
            Console.WriteLine("Count of Numbers with Repeating Digits: "+CountOfNumbersWithRepeatingDigits);
        }
        public static void Main(string[] args)
        {
            SameDigits sameDigits = new SameDigits();
            sameDigits.findRepeatingDigitsCount();
        }
    }
}
