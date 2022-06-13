using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleHelp
{
    public class Letters
    {
        private char[] _correctLetters = new char[5] { '.', '.', '.', '.', '.' };
        private HashSet<char> _wrongLetters = new HashSet<char>();
        private string[] _differentPlace = new string[5];
   

        public HashSet<char> WrongLetters
        {
            get { return _wrongLetters; }
        }
        public char[] CorrectLetters
        {
            get { return _correctLetters; }
        }
        public string DifferentPlace(int index)
        {
            return _differentPlace[index];
        }

        public void handleGuess(string word, string score)
        {
            for(int i = 0; i < word.Length; i++)
            {
                char letterScore = score[i];

                switch (letterScore)
                {
                    case 'G':
                        _correctLetters[i] = word[i];
                        break;
                    case 'Y':
                        _differentPlace[i] += word[i];
                        break;
                    default:
                        _wrongLetters.Add(word[i]);
                        break;

                }
            }
        }
    }
}
