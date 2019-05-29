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
            this.DataContext = totalPrize;
        }

        public void GetOrder()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            totalPrize = CalculateTotalPrize(mainWindow.basket.ItemsInBasket);
            AddItemsToSummary(mainWindow.basket.ItemsInBasket);
            ChangeTotalPrizeText();
        }
        
        private void ChangeTotalPrizeText()
        {
            TotalPrize.Text = string.Format("Total prize: {0} PLN", totalPrize.ToString());
        }

        private void AddItemsToSummary(List<Pizza> pizzas)
        {
            foreach(Pizza pizza in pizzas)
            {
                OrderList.Items.Add(pizza);
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
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.basket.ItemsInBasket.Clear();
            mainWindow.BasketList.Items.Clear();
            OrderList.Items.Clear();
            ChangeTotalPrizeText();
            Hide();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
