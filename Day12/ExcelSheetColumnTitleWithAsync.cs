using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class ExcelSheetColumnTitle
    {
        public async Task<string> CalculateExcelSheetColumnTitle()
        {
            int n = await GetInputFromUser();
            Dictionary<int, char> AlphabetValues = await AssignAlphabetValues();

            string Result = "";


            if (n <= 26)
                Result += AlphabetValues[n];
            else
            {
                int temp = n;
                int divide = 0, diff = 0;
                while (temp > 26)
                {
                    divide = temp / 26;
                    diff = temp - (divide * 26);
                    if (diff == 0)
                    {
                        Result = AlphabetValues[26] + Result;
                        divide -= 1;
                    }
                    else
                        Result = AlphabetValues[diff] + Result;
                    temp = divide;
                }
                Result = AlphabetValues[temp] + Result;
            }
            return Result;
        }
        public async Task<Dictionary<int, char>> AssignAlphabetValues()
        {
            Dictionary<int, char> AlphabetValues = new Dictionary<int, char>();
            char Alphabet = 'A';
            for (int i = 1; i <= 26; i++)
                AlphabetValues[i] = Alphabet++;
            return AlphabetValues;
        }

        public async Task<int> GetInputFromUser()
        {
            Console.WriteLine("Enter the column number to be converted: ");
            int n = Convert.ToInt32(Console.ReadLine());
            return n;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(new ExcelSheetColumnTitle().CalculateExcelSheetColumnTitle().Result);
        }
    }
}
