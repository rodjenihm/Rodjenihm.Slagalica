using Rodjenihm.Slagalica.CustomControls;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rodjenihm.Slagalica
{
    public static class Utilities
    {
        public static bool IsMatch(string word, IEnumerable<string> letters)
        {
            var let = letters.ToList();
            foreach (var letter in word)
            {
                var s = letter.ToString();
                if (!let.Contains(s))
                {
                    return false;
                }
                else
                {
                    let.Remove(s);
                }
            }
            return true;
        }

        public static bool ValidateInput(IEnumerable<InputLetterTextBox> inputLetters)
        {
            var valid = true;
            var regex = new Regex(@"\b([abcčćdđefghijklmnoprsštuvzž]|(dž)|(lj)|(nj))\b");
            foreach (var inputLetter in inputLetters)
            {
                var validLetter = regex.Match(inputLetter.Text).Success;
                valid &= validLetter;
                if (!validLetter)
                {
                    inputLetter.Clear();
                }
            }
            return valid;
        }
    }
}
