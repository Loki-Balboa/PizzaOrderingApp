using System.Reflection;
using ExtensionMethods;
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
                if (value.ContainsOnlyLetters())
                {
                    firstName = value;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Name contains special characters", "Invalid name");
                }
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (value.ContainsOnlyLetters())
                {
                    lastName = value;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Name contains special characters", "Invalid name");
                }
            }
        }
        public string Street
        {
            get => street;
            set
            {
                if(value.IsValidStreet())
                {
                    street = value;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Street name is invalid ", "Invalid street");
                }
            }
        }
        public string StreetPt2
        {
            get => streetPt2;
            set
            {
                if (value.IsValidStreet())
                {
                    streetPt2 = value;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Street name is invalid ", "Invalid street");
                }
            }
        }
        public string City
        {
            get => city;
            set
            {
                if (value.ContainsOnlyLetters())
                {
                    city = value;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("City name is invalid", "Invalid city");
                }
            }
        }
        public string Zip
        {
            get => zip;
            set
            {
                if(value.IsValidZip())
                {
                    zip = value;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Zip code is invalid", "Invalid zip code");
                }
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (value.IsValidEmail())
                {
                    email = value;
                }
                else
                {
                    MessageBoxResult invalidEmail = MessageBox.Show("Email adress is invalid", "Invalid email");
                }
            }
        }
        public string PhoneNr
        {
            get => phoneNr;
            set
            {
                if (value.IsValidPhoneNr())
                {
                    phoneNr = value;
                }
                else
                {
                    MessageBoxResult invalidPhoneNr = MessageBox.Show("Phone number is invalid", "Invalid phone number");
                }
            }
        }
        private string firstName;
        private string lastName;
        private string street;
        private string streetPt2;
        private string city;
        private string zip;
        private string email;
        private string phoneNr;

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