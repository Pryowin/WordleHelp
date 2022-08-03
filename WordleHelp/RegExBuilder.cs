using System.Text;
using System.Text.RegularExpressions;

namespace WordleHelp
{
    public class RegExBuilder
    {
        const char OR = '|';
        const char ANYCHAR = '.';

        public Regex OmitWrongPlace(string[] wrongPlace)
        {
            StringBuilder reg = new StringBuilder();

            foreach(string letters in wrongPlace)
            {
                if (letters == null) 
                {
                    reg.Append(ANYCHAR);
                } 
                else
                {
                    reg.Append(NegatedList(letters));
                }
            }

            return new Regex(reg.ToString()); ;
        }
        public Regex IncludeWrongPlace(string[] wrongPlace)
        {
            StringBuilder reg = new StringBuilder("[.?");
            foreach(string letters in wrongPlace)
            {
                foreach(char letter in letters)
                {
                    reg.Append(letter);
                    reg.Append(OR);
                }
                
            }
            reg.Remove(reg.ToString().Length - 1, 1);
            reg.Append(".?]");

            return new Regex(reg.ToString()); ;

        }
        private string NegatedList(string letters)
        {
            StringBuilder reg = new StringBuilder();

            reg.Append("[^");
            foreach(char letter in letters)
            {
                reg.Append(letter);
                reg.Append(OR);
            }
            reg.Remove(reg.ToString().Length - 1, 1);
            reg.Append(']');
            return reg.ToString();
        }
    }
}
