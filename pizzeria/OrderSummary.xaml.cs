using System.Collections.Generic;
using System.Windows;
using System.IO;
using System;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for OrderSummary.xaml
    /// </summary>
    public partial class OrderSummary : Window
    {
        public float totalPrize { get; set; }
        public OrderSummary()
        {
            InitializeComponent();
            this.DataContext = totalPrize;
        }

        public void GetOrder()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            totalPrize = CalculateTotalPrize(mainWindow.order.ItemsInBasket);
            AddItemsToSummary(mainWindow.order.ItemsInBasket);
            ChangeTotalPrizeText();
        }
        
        private void ChangeTotalPrizeText()
        {
            TotalPrize.Text = string.Format("Total prize: {0} PLN", totalPrize.ToString());
        }

        private void AddItemsToSummary(List<MenuItem> items)
        {
            foreach(MenuItem item in items)
            {
                OrderList.Items.Add(item);
            }
        }
        private float CalculateTotalPrize(List<MenuItem> items)
        {
            float totalPrize = 0;
            foreach (MenuItem item in items)
            {
                totalPrize += item.Prize;
            }
            return totalPrize;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            WriteToFile(mainWindow.order.ItemsInBasket);
            mainWindow.order.ItemsInBasket.Clear();
            mainWindow.BasketList.Items.Clear();
            mainWindow.OrderPanel.Visibility = Visibility.Collapsed;
            mainWindow.EmptyLabel.Visibility = Visibility.Visible;
            OrderList.Items.Clear();
            ChangeTotalPrizeText();
            Hide();
        }

        private void WriteToFile(List<MenuItem> menuItems)
        {
            string currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            int orderNumber = 1;
            StreamWriter orderFile = File.CreateText(currentPath + String.Format(@"\data\orders\order#{0}.txt", orderNumber));
            orderFile.WriteLine(String.Format("Order#{0}:", orderNumber));
            orderFile.WriteLine(DateTime.Now.ToString());

            foreach (MenuItem item in menuItems)
            {
                orderFile.WriteLine(item.Name + " " + item.Prize);
            }
            orderFile.WriteLine(String.Format("Sum:{0}", totalPrize));
            orderFile.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Clear();
            Hide();
        }
    }
}
