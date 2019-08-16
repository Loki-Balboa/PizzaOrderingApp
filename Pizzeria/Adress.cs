using System.Reflection;

namespace Pizzeria
{
    public class Adress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string StreetPt2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }

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