using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class CardValidation
    {
        /// <summary>
        /// Checks if the provided CardNumber has only numbers
        /// </summary>
        /// <param name="cardNumber">Provide the CardNumber as string</param>
        /// <returns></returns>
        static bool CheckCardNumber(string cardNumber)
        {
            if(cardNumber.All(char.IsDigit))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validates the CardNumber using the algorithm
        /// </summary>
        /// <param name="cardNumber">Provide the CardNumber as string</param>
        static void ValidateCardNumber(string cardNumber)
        {
            int result = 0;
            for (int i = 0; i < cardNumber.Length; i++)
            {
                int num = Convert.ToInt32(cardNumber[i].ToString());
                if ((i + 1) % 2 != 0)
                {
                    result += num;
                }
                else
                {
                    num *= 2;
                    if (num >= 10)
                    {
                        result += (num % 10) + ((num / 10) % 10);
                    }
                    else
                    {
                        result += num;
                    }
                }
            }
            PrintValidityOfCardNumber(result);
        }

        /// <summary>
        /// Prints whether the provided CardNumber is valid or not
        /// </summary>
        /// <param name="result">Provide the calculated sum of each digit from the CardNumber</param>
        static void PrintValidityOfCardNumber(int result)
        {
            if (result % 10 == 0)
            {
                Console.WriteLine("It is a Valid Card Number");
            }
            else
            {
                Console.WriteLine("Invalid Card Number");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter your Card Number: ");
            string CardNumber = Console.ReadLine() ?? "";
            while ((CardNumber.Length != 16) || (!CheckCardNumber(CardNumber)))
            {
                Console.WriteLine("Please Enter a Valid Card Number: ");
                CardNumber = Console.ReadLine() ?? "";
            }
            string ReversedCardNumber = "";
            for (int i = CardNumber.Length - 1; i >= 0; i--)
            {
                ReversedCardNumber += CardNumber[i];
            }
            ValidateCardNumber(ReversedCardNumber);
        }
    }
}
