using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class HangmanUI
    {
        public string pOneName;
        public int pOneScore = 0;
        public int wrongGuesses = 0;
        //public static string[] gameWords = new string[] //this array of words was moved to WordRepo
        public string wordToGuess;
        public string wordSpaces;
        private readonly WordRepo _wordRepo;
        public HangmanUI(WordRepo wordRepo)
        {
            _wordRepo = wordRepo;
        }
        public void Run()
        {
            RunGame();
        }
        private void RunGame()
        {

            Console.WriteLine("Enter your name");
            pOneName = Console.ReadLine();

            wordToGuess = _wordRepo.GetGuessWord();//Still don't understand why this works
            // Remove comment for testing Console.WriteLine(wordToGuess);

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordSpaces += "_";
            }

            while (wrongGuesses < 6 && wordSpaces.Contains("_"))
            {

                Console.WriteLine($"You word has {wordToGuess.Length} characters in it.");
                Console.WriteLine(wordSpaces);
                Console.WriteLine("Please enter your guess:");
                string guess = Console.ReadLine();

                if (wordToGuess.Contains(guess))
                {
                    Console.WriteLine("Good job! You guessed correctly!");//moved up here so it will only display once if wordToGuess.Contains(guess) == true
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i].ToString().ToLower() == guess) //added .ToLower()
                        {
                            wordSpaces = wordSpaces.Remove(i, 1); //returns a string
                            wordSpaces = wordSpaces.Insert(i, guess); //returns a string
                        }
                    }
                    Console.WriteLine(wordSpaces);
                }
                else
                {
                    wrongGuesses++;
                    switch (wrongGuesses)
                    {
                        case 1:
                            Console.WriteLine("You guessed incorrectly");
                            Console.WriteLine("    O    ");
                            break;
                        case 2:
                            Console.WriteLine("You guessed incorrectly");
                            Console.WriteLine("  __O    ");
                            break;
                        case 3:
                            Console.WriteLine("You guessed incorrectly");
                            Console.WriteLine("  __O__  ");
                            break;
                        case 4:
                            Console.WriteLine("You guessed incorrectly");
                            Console.WriteLine("  __O__  ");
                            Console.WriteLine("    |    ");
                            break;
                        case 5:
                            Console.WriteLine("You guessed incorrectly");
                            Console.WriteLine("  __O__  ");
                            Console.WriteLine("    |    ");
                            Console.WriteLine("   /     ");
                            break;
                        case 6:
                            Console.WriteLine("You guessed incorrectly. Also, he's not ice skating, his limbs are flailing, because you killed him.");
                            Console.WriteLine("  __O__  ");
                            Console.WriteLine("    |__  ");
                            Console.WriteLine("   /     ");
                            Console.WriteLine($"Sorry, {pOneName}. You've run out of guesses. Better luck next time.");
                            break;
                        default:
                            break;
                    }
                }
                if (!wordSpaces.Contains("_"))
                {
                    Console.WriteLine($"Well done, {pOneName}! You guessed the word!");
                    break;
                }
            }
            Console.WriteLine("End of game. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
