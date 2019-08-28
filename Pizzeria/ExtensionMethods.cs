using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool ContainsOnlyLetters(this string str)
        {
            if (Regex.IsMatch(str, "^[a-zA-Z]+$")) return true;
            else return false;
        }

        public static bool IsValidZip(this string zip)
        {
            if (zip.IsPolishZip() ||
                zip.IsAmericanZip()) return true;
            else return false;
        }

        private static bool IsPolishZip(this string zip)
        {
            if (Regex.IsMatch(zip, "^[0-9-]+$") &&
                zip[2] == '-' &&
                zip.Length == 6) return true;
            else return false;
        }

        private static bool IsAmericanZip(this string zip)
        {
            if (Regex.IsMatch(zip, "^[0-9]+$") && zip.Length == 5) return true;
            else return false;
        }

        public static bool IsValidStreet(this string street)
        {
            if (Regex.IsMatch(street, @"^[a-zA-Z0-9./\s*]+$")) return true;
            else return false;
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                string[] emailSplit = email.Split('@');
                string name = emailSplit[0];
                string domain = emailSplit[1];

                if (emailSplit.Length == 2 &&
                    name.IsValidEmailName() &&
                    domain.IsCorrectDomain())
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

        private static bool IsValidEmailName(this string str)
        {
            if (Regex.IsMatch(str, "^[a-zA-Z0-9_.]+$")) return true;
            else return false;
        }

        private static bool IsCorrectDomain(this string domain)
        {
            try
            {
                string[] domainSplit = domain.Split('.');
                if (domainSplit.Length == 2 &&
                    domainSplit[1].ContainsOnlyLetters())
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

        private static bool ContainsOnlyLettersAndNumbers(this string str)
        {
            if (Regex.IsMatch(str, "^[a-zA-Z0-9]+$")) return true;
            else return false;
        }

        public static bool IsValidPhoneNr(this string phoneNr)
        {
            if (phoneNr.IsWithCountryCode() ||
                phoneNr.IsWithoutCountryCode()) return true;
            else return false;
        }

        private static bool IsWithCountryCode(this string phoneNr)
        {
            if (Regex.IsMatch(phoneNr, "^[0-9+]+$") && 
                phoneNr.Contains('+') &&
                phoneNr.Length == 12) return true;
            else return false;
        }

        private static bool IsWithoutCountryCode(this string phoneNr)
        {
            if (Regex.IsMatch(phoneNr, "^[0-9]+$") && phoneNr.Length == 9) return true;
            else return false;
        }
    }
}
