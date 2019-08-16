using System;
using System.Collections.Generic;
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
            get { return Pizzeria.Properties.Settings.Default.OrderNumber; }
            set
            {
                Pizzeria.Properties.Settings.Default.OrderNumber = value;
                Pizzeria.Properties.Settings.Default.Save();
            }
        }
        public Order()
        {
            ItemsInBasket = new ObservableCollection<MenuItem>();
        }
        public void WriteToFile()
        {
            string currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            orderFile = File.CreateText(currentPath + String.Format(@"\data\orders\order#{0}.txt", OrderNumber));
            orderFile.WriteLine(String.Format("Order#{0}:", OrderNumber));
            orderFile.WriteLine(DateTime.Now.ToString());
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

        public void CalculateTotalPrize()
        {
            TotalPrize = 0;
            foreach (MenuItem item in ItemsInBasket)
            {
                TotalPrize += item.CurrentPrice;
            }
        }
    }
}
