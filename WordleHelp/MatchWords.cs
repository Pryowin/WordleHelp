using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
