using System.Text;
using System.Text.RegularExpressions;

namespace WordleHelp
{
    public class RegExBuilder
    {
        const char Or = '|';
        const char AnyChar = '.';

        public Regex OmitWrongPlace(string[] wrongPlace)
        {
            StringBuilder reg = new StringBuilder();

            foreach(string letters in wrongPlace)
            {
                if (letters == null || letters == "")
                {
                    reg.Append(AnyChar);
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
                if(letters is null)
                {
                    continue;
                }
                foreach(char letter in letters)
                {
                    reg.Append(letter);
                    reg.Append(Or);
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
                reg.Append(Or);
            }
            reg.Remove(reg.ToString().Length - 1, 1);
            reg.Append(']');
            return reg.ToString();
        }
    }
}
