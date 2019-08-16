using System.Reflection;
using ExtensionMethods;
using System.Text.RegularExpressions;
using System.Windows;

namespace Pizzeria
{
    public class Adress
    {
        public string FirstName
        {
            get => firstName;
            set
            {
                if (ExtensionMethods.StringChecks.ContainsSpecialCharacters(value))
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Name contains special characters", "Invalid name");
                }
                else firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (ExtensionMethods.StringChecks.ContainsSpecialCharacters(value))
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Name contains special characters", "Invalid name");
                }
                else lastName = value;
            }
        }
        public string Street { get; set; }
        public string StreetPt2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        private string firstName;
        private string lastName;

        public bool IsComplete()
        {
            bool isAdressComplete = true;
            PropertyInfo[] properties = this.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] == this.GetType().GetProperty("StreetPt2")) continue;
                if (properties[i].GetValue(this) == null) isAdressComplete = false;
            }
            return isAdressComplete;
        }
    }
}