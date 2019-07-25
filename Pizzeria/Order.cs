﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Pizzeria
{
    public class Order
    {
        public List<MenuItem> ItemsInBasket { get; set; }
        public float TotalPrize { get; set; }
        public int OrderNumber
        {
            get { return pizzeria.Properties.Settings.Default.OrderNumber; }
            set
            {
                pizzeria.Properties.Settings.Default.OrderNumber = value;
                pizzeria.Properties.Settings.Default.Save();
            }
        }
        public Order()
        {
            ItemsInBasket = new List<MenuItem>();
        }
        public void WriteToFile()
        {
            string currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            StreamWriter orderFile = File.CreateText(currentPath + String.Format(@"\data\orders\order#{0}.txt", OrderNumber));
            orderFile.WriteLine(String.Format("Order#{0}:", OrderNumber));
            orderFile.WriteLine(DateTime.Now.ToString());

            foreach (MenuItem item in ItemsInBasket)
            {
                orderFile.WriteLine(String.Format("{0} {1} PLN",item.Name, item.Prize));
            }
            orderFile.WriteLine(String.Format("Sum:{0} PLN", TotalPrize));
            orderFile.Close();
            OrderNumber += 1;
        }
        public void CalculateTotalPrize()
        {
            TotalPrize = 0;
            foreach (MenuItem item in ItemsInBasket)
            {
                TotalPrize += item.Prize;
            }
        }
    }
}
