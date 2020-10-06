using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Hangman
    {
        static void Main(string[] args)
        {
            WordRepo wordRepo = new WordRepo();
            HangmanUI ui = new HangmanUI(wordRepo);
            ui.Run();
        }
    }
}
