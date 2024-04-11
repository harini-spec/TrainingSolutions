// Take a string from user the words seperated by comma(","). 
// Seperate the words and find the words with the least number of repeating vowels. 
// Print the count and the word. If there is a tie then print all the words that tie for the least
// Hello, Welcome, Bye
// o - 2
// Number of words - 3
// Word that has the least vowels - Bye

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class Qn7
    {
        static string GetInputString()
        {
            string inpstring = Console.ReadLine()??"Null";
            return inpstring;
        }
        static string[] GetWordArray(string InpString)
        {
            string[] words = InpString.Split(",");
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            return words;
        }

        static void FindLeastVowelWord()
        {
            string InpString = GetInputString();
            string[] words = GetWordArray(InpString);
            int[] VowelCount = new int[words.Length];
            for(int i=0;i<words.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (!String.Equals(words[i],"Null") && (words[i][j] == 'a' || words[i][j] == 'e' || words[i][j] == 'i' || words[i][j] == 'o' || words[i][j] == 'u' || words[i][j] == 'A' || words[i][j] == 'E' || words[i][j] == 'I' || words[i][j] == 'O' || words[i][j] == 'U'))
                        {
                            count++;
                        }
                }
                VowelCount[i] = count;
            }
            PrintLeastVowelWord(VowelCount, words);
        }

        static void PrintLeastVowelWord(int[] VowelCount, string[] words)
        {
            int minCount = VowelCount.Min();
            for (int i = 0; i < VowelCount.Length; i++)
            {
                if (VowelCount[i] == minCount)
                {
                    Console.WriteLine($"{words[i]} - {VowelCount[i]}");
                }
            }
        }

        static void Main(string[] args)
        {
            FindLeastVowelWord();
        }
    }
}
