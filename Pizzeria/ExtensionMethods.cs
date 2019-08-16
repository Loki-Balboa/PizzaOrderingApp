using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class StringChecks
    {
        public static bool ContainsSpecialCharacters(string stringToCheck)
        {
            Regex regularCharacters = new Regex("[^a-zA-Z]");
            if (regularCharacters.IsMatch(stringToCheck)) return true;
            else return false;
        }
    }
}
