using System;

namespace WordleHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new Words().WordList;
            Letters letters = new Letters();
            const string exitString = "!x";
            
            bool exit = false;

            do
            {
                Console.WriteLine("Enter Word or {0} to Exit", exitString);
                string guess = Console.ReadLine().ToLower().Trim();
                if (guess == exitString)
                {
                    exit = true;
                    continue;
                }
                Console.WriteLine("Enter Score [G,Y,B]");
                string score = Console.ReadLine().ToUpper().Trim();
                letters.handleGuess(guess, score);
                MatchWords wordList = new MatchWords();
                words = wordList.ApplyAllFilters(words, letters);
                Console.WriteLine("Show {0} possible words (Y/N)", words.Length);
                string show = Console.ReadLine().ToUpper().Trim();
                if(show == "Y")
                {
                    foreach(string word in words)
                    {
                        Console.WriteLine(word);
                    }
                }


            } while (!exit);
        }
    }
}
