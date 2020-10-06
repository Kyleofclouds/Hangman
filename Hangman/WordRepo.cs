using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class WordRepo
    {
        protected readonly string[] _wordRepo = new string[] { "sheep", "optimal", "quiet", "watermelon", "cake", "nondescript", "lettuce", "few", "excellent", "defeated" };

        public string GetGuessWord()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, _wordRepo.Length - 1);
            string randoWord = _wordRepo[randomNumber];
            return randoWord;
        }
    }
}
