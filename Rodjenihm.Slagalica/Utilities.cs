using Rodjenihm.Slagalica.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
