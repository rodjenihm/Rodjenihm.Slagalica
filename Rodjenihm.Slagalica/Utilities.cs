using Rodjenihm.Slagalica.CustomControls;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            var regex = new Regex(@"^([abcčćdđefghijklmnoprsštuvzž]|dž|lj|nj)$", RegexOptions.IgnoreCase);
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

        public static IEnumerable<string> GetSolutions(IEnumerable<string> letters, int n = 1)
        {
            return WordList.Instance.Words.Where(w => IsMatch(w, letters)).Take(n);
        }

        public static void DisplaySolutions(IEnumerable<string> solutions, TextBox output)
        {
            solutions.ToList().ForEach(s => output.Text += s.Replace("1", "dž").Replace("2", "lj").Replace("3", "nj") + "\r\n");
        }
    }
}
