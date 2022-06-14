using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WordleHelp
{
    public class RegExBuilder
    {
        public Regex OmitWrongPlace(string[] wrongPlace)
        {
            StringBuilder reg = new StringBuilder();

            foreach(string letters in wrongPlace)
            {
                if (letters.Length == 0)
                {
                    reg.Append('.');
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
                    reg.Append('|');
                }
                reg.Remove(reg.ToString().Length - 1, 1);
                reg.Append(".?]");
            }
            return new Regex(reg.ToString()); ;

        }
        private string NegatedList(string letters)
        {
            StringBuilder reg = new StringBuilder();

            reg.Append("[^");
            foreach(char letter in letters)
            {
                reg.Append(letter);
                reg.Append('|');
            }
            reg.Remove(reg.ToString().Length - 1, 1);
            reg.Append(']');
            return reg.ToString();
        }
    }
}
