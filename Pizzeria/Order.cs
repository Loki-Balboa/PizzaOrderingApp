using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace Pizzeria
{
    public class Order
    {
        public ObservableCollection<MenuItem> ItemsInBasket { get; set; }
        public float TotalPrize { get; set; }
        public Adress Adress { get; set; }
        private StreamWriter orderFile;
        private int OrderNumber
        {
            get => Properties.Settings.Default.OrderNumber; 
            set
            {
                Properties.Settings.Default.OrderNumber = value;
                Properties.Settings.Default.Save();
            }
        }

        public Order()
        {
            ItemsInBasket = new ObservableCollection<MenuItem>();
        }

        public void CalculateTotalPrize()
        {
            TotalPrize = 0;
            foreach (MenuItem item in ItemsInBasket)
            {
                TotalPrize += item.CurrentPrice;
            }
        }

        public void WriteToFile()
        {
            string currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            Directory.CreateDirectory(currentPath + @"\data\orders");
            orderFile = File.CreateText(currentPath + String.Format(@"\data\orders\order#{0}.txt", OrderNumber));
            WriteTitleAndDate();
            WriteOrder();
            WriteAdress();
            orderFile.Close();
            OrderNumber += 1;
        }

        private void WriteOrder()
        {
            foreach (MenuItem item in ItemsInBasket)
            {
                orderFile.WriteLine(String.Format("{0} {1} PLN", item.Name, item.BasePrice));
            }

            orderFile.WriteLine(String.Format("Sum:{0} PLN", TotalPrize));
        }

        private void WriteAdress()
        {
            orderFile.WriteLine("Delivery adress:");
            foreach (PropertyInfo propInfo in Adress.GetType().GetProperties())
            {
                orderFile.Write(String.Format("{0}: ", propInfo.Name));
                try
                {
                    string propValue = propInfo.GetValue(Adress).ToString();
                    orderFile.Write(String.Format("{0}\n", propValue));
                }
                catch (NullReferenceException)
                {
                    orderFile.Write("\n");
                }
            }
        }

        private void WriteTitleAndDate()
        {
            orderFile.WriteLine(String.Format("Order#{0}:", OrderNumber));
            orderFile.WriteLine(DateTime.Now.ToString());
        }
    }
}
