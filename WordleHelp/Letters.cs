using System.Collections.Generic;

namespace WordleHelp
{
    public class Letters
    {
        const int WordLength = 5;
        const char RightPlace = 'G';
        const char WrongPlace = 'Y';
        const char AnyChar = '.';

        private char[] _correctLetters = new char[WordLength] { AnyChar, AnyChar, AnyChar, AnyChar, AnyChar };
        private HashSet<char> _wrongLetters = new HashSet<char>();
        private HashSet<char> _usedLetters = new HashSet<char>();
        private string[] _differentPlace = new string[WordLength];
   

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
        public string[] DifferentPlaces
        {
            get { return _differentPlace; }
        }

        public void handleGuess(string word, string score)
        {
            for(int i = 0; i < word.Length; i++)
            {
                 char letterScore = score[i];

                switch (letterScore)
                {
                    case RightPlace:
                        _correctLetters[i] = word[i];
                        _usedLetters.Add(word[i]);
                        break;
                    case WrongPlace:
                        _differentPlace[i] += word[i];
                        _usedLetters.Add(word[i]);
                        break;
                    default:
                        break;

                }   
            }
            for (int i = 0; i < word.Length; i++)
            {
                char letterScore = score[i];
                if (letterScore != RightPlace && letterScore != WrongPlace && !_usedLetters.Contains(word[i]))
                {
                    _wrongLetters.Add(word[i]);
                }
            }
        }
    }
}
