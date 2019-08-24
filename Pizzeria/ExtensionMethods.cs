using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class StringChecks
    {
        public static bool ContainsOnlyLetters(string stringToCheck)
        {
            if (Regex.IsMatch(stringToCheck, "^[a-zA-Z]+$")) return true;
            else return false;
        }

        public static bool IsValidZip(string zip)
        {
            if (IsPolishZip(zip) ||
                IsAmericanZip(zip)) return true;
            else return false;
        }

        private static bool IsPolishZip(string zip)
        {
            if (Regex.IsMatch(zip, "^[0-9-]+$") &&
                zip.Contains('-') &&
                zip.Length == 6) return true;
            else return false;
        }

        private static bool IsAmericanZip(string zip)
        {
            if (Regex.IsMatch(zip, "^[0-9]+$") && zip.Length == 5) return true;
            else return false;
        }

        public static bool IsValidStreet(string street)
        {
            if (Regex.IsMatch(street, "^[a-zA-Z0-9/]+$")) return true;
            else return false;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                string[] emailSplit = email.Split('@');
                string name = emailSplit[0];
                string domain = emailSplit[1];

                if (emailSplit.Length == 2 &&
                    ContainsOnlyLettersAndNumbers(name) &&
                    IsCorrectDomain(domain))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        private static bool IsCorrectDomain(string domain)
        {
            try
            {
                string[] domainSplit = domain.Split('.');
                if (domainSplit.Length == 2 &&
                    ContainsOnlyLetters(domainSplit[1]))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ContainsOnlyLettersAndNumbers(string stringToCheck)
        {
            if (Regex.IsMatch(stringToCheck, "^[a-zA-Z0-9]+$")) return true;
            else return false;
        }

        public static bool IsValidPhoneNr(string phoneNr)
        {
            if (IsWithCountryCode(phoneNr) ||
                IsWithoutCountryCode(phoneNr)) return true;
            else return false;
        }

        private static bool IsWithCountryCode(string phoneNr)
        {
            if (Regex.IsMatch(phoneNr, "^[0-9+]+$") && 
                phoneNr.Contains('+') &&
                phoneNr.Length == 12) return true;
            else return false;
        }

        private static bool IsWithoutCountryCode(string phoneNr)
        {
            if (Regex.IsMatch(phoneNr, "^[0-9]+$") && phoneNr.Length == 9) return true;
            else return false;
        }
    }
}
