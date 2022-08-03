using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordleHelp
{
    public class MatchWords
    {
        public string[] SelectMatched(string[] words, char[] letters)
        {
            string reg = new string(letters);
            Regex regex = new Regex(reg);
            var retVal =  words.Where(word => regex.IsMatch(word)).ToArray<string>();
            return retVal;
        }
        public string[] ExcludeNonMatched(string[] words, HashSet<char> letters)
        {
            string[] retVal = words;
            foreach (char letter in letters)
            {
                retVal = retVal.Where(word => !word.Contains(letter)).ToArray<string>();
            }
            return retVal;
         
        }
        public string[] ExcludeWrongPosition(string[] words, string[] wrongPosition)
        {
            RegExBuilder reg = new RegExBuilder();
            Regex regex = reg.OmitWrongPlace(wrongPosition);
            string[] retVal = words.Where(word => regex.IsMatch(word)).ToArray<string>();

            return retVal;
        }
        public string[] IncludeWrongPosition(string[] words, string[] wrongPosition)
        {
            string letters =string.Join("", wrongPosition);
            string[] retVal = words.Where(word => letters.All(word.Contains)).ToArray<string>();
            return retVal;
        }
        public string[] ApplyAllFilters(string[] words, Letters letters)
        {
            words = ExcludeNonMatched(words, letters.WrongLetters);
            words = SelectMatched(words, letters.CorrectLetters);
            words = ExcludeWrongPosition(words, letters.DifferentPlaces);
            words = IncludeWrongPosition(words, letters.DifferentPlaces);
            return words;

        }
    }
}
