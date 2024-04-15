// Program written for two players. Prints the attempt at which the player found the word along with cows and bulls

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class CowBull
    {
        string SecretWord;
        public CowBull() 
        {
            SecretWord = "golf";
        }

        /// <summary>
        /// Alternates turns between two players
        /// </summary>
        void PlayersTurn()
        {
            int player = 1;
            bool found = false;
            int playerOneAttempt = 0;
            int playerTwoAttempt = 0;
            while (!found)
            {
                Console.WriteLine($"Player {player}'s turn. Enter your guess:");
                if (player == 1)
                {
                    playerOneAttempt++;
                    found = PlayGuessingGame(player, playerOneAttempt);
                    player = 2;
                }
                else
                {
                    playerTwoAttempt++;
                    found = PlayGuessingGame(player, playerTwoAttempt);
                    player = 1;
                } 
            }
        }

        /// <summary>
        /// Prints cows and bulls count and success message
        /// </summary>
        /// <param name="player">Player number as int</param>
        /// <param name="attempt">Specific Player's attempt as int</param>
        /// <returns></returns>
        bool PlayGuessingGame(int player, int attempt)
        {
            bool found = false;
            string GuessWord = GetGuessWord();
            int CowsCount = FindCowsCount(GuessWord);
            int BullsCount = FindBullsCount(GuessWord);
            Console.WriteLine($"Cows:{CowsCount} \t Bulls:{BullsCount} ");
            if (CowsCount == SecretWord.Length)
            {
                Console.WriteLine($"Congrats! You've won player {player} at attempt {attempt}!!!!");
                found = true;
            }
            return found;
        }

        /// <summary>
        /// Replaces the guessed word's characters which are found at the same position in the secret word with #
        /// </summary>
        /// <param name="guess">User's guessed word as string</param>
        /// <returns>Hashed guessed word as StringBuilder</returns>
        StringBuilder HashGuessWord(string guess)
        {
            StringBuilder GuessWord = new StringBuilder(guess);
            for (int i = 0; i < SecretWord.Length; i++)
            {
                if (GuessWord[i] == SecretWord[i])
                {
                    GuessWord[i] = '#';
                }
            }
            return GuessWord;
        }

        /// <summary>
        /// Replaces the secret word's characters which are found at the same position in the guessed word with #
        /// </summary>
        /// <param name="guess">User's guessed word as string</param>
        /// <returns>Hashed secret word as StringBuilder</returns>
        StringBuilder HashSecretWord(string guess)
        {
            StringBuilder SecretWordSB = new StringBuilder(SecretWord);
            for (int i = 0; i < SecretWord.Length; i++)
            {
                if (SecretWordSB[i] == guess[i])
                {
                    SecretWordSB[i] = '#';
                }
            }
            return SecretWordSB;
        }

        /// <summary>
        /// Finds Bulls count - same characters present at different position
        /// </summary>
        /// <param name="guess">User's guessed word</param>
        /// <returns>Bulls count as int</returns>
        int FindBullsCount(string guess)
        {
            int BullsCount = 0;
            StringBuilder GuessWordHash = HashGuessWord(guess);
            StringBuilder SecretWordHash = HashSecretWord(guess);
            for (int i = 0; i < SecretWordHash.Length; i++)
            {
                for(int j = 0; j < GuessWordHash.Length; j++)
                {
                    if (GuessWordHash[j] != '#' && SecretWordHash[i] != '#' && GuessWordHash[j] == SecretWordHash[i])
                    {
                        BullsCount++;
                        GuessWordHash[j] = '#';
                        SecretWordHash[i] = '#';
                        break;
                    }
                }
            }
            return BullsCount;
        }

        /// <summary>
        /// Finds Cows count - same characters present at same position
        /// </summary>
        /// <param name="guess">User's guessed word</param>
        /// <returns>cows count as int</returns>
        int FindCowsCount(string guess)
        {
            int CowsCount = 0;
            for(int i = 0; i < guess.Length; i++)
            {
                if (SecretWord[i] == guess[i])
                    CowsCount++;
            }
            return CowsCount;
        }

        /// <summary>
        /// Gets the guess from the user - must be a 4 character word 
        /// </summary>
        /// <returns>Guess word as string</returns>
        string GetGuessWord()
        {
            string GuessWord = Console.ReadLine()??string.Empty;
            while(GuessWord.Length != 4)
            {
                Console.WriteLine("Enter a 4 character word");
                GuessWord = Console.ReadLine() ?? string.Empty;
            }
            return GuessWord;
        }

        public static void Main(string[] args) 
        {
            CowBull cowBull = new CowBull();
            cowBull.PlayersTurn();
        }

    }
}