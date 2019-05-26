using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

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
        }

        public void GetOrder()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            totalPrize = CalculateTotalPrize(mainWindow.basket.ItemsInBasket);
            //AddItemsToSummary(mainWindow.basket.ItemsInBasket);
            TotalPrize.Text = string.Format("Total prize: {0} PLN", totalPrize.ToString());
        }
        
        private void AddItemsToSummary(List<Pizza> pizzas)
        {
            foreach(Pizza pizza in pizzas)
            {
                //OrderSummary.Items.Add(pizza);
            }
        }
        private float CalculateTotalPrize(List<Pizza> pizzas)
        {
            float totalPrize = 0;
            foreach (Pizza pizza in pizzas)
            {
                totalPrize += pizza.Prize;
            }
            return totalPrize;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
