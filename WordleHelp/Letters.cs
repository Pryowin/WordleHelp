using System.Collections.Generic;

namespace WordleHelp
{
    public class Letters
    {
        const int wordLength = 5;
        const char rightPlace = 'G';
        const char wrongPlace = 'Y';

        private char[] _correctLetters = new char[wordLength] { '.', '.', '.', '.', '.' };
        private HashSet<char> _wrongLetters = new HashSet<char>();
        private string[] _differentPlace = new string[wordLength];
   

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
                    case rightPlace:
                        _correctLetters[i] = word[i];
                        break;
                    case wrongPlace:
                        _differentPlace[i] += word[i];
                        break;
                    default:
                        break;

                }   
            }
            for (int i = 0; i < word.Length; i++)
            {
                char letterScore = score[i];
                if (letterScore != rightPlace && letterScore != wrongPlace)
                {
                    _wrongLetters.Add(word[i]);
                }
            }
        }
    }
}
