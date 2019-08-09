using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for OrderSummary.xaml
    /// </summary>
    public partial class OrderSummaryWindow : Window
    {
        public OrderSummaryWindow()
        {
            InitializeComponent();
        }
        public void GetOrder()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.order.CalculateTotalPrize();
            AddItemsToSummary(mainWindow.order.ItemsInBasket);
            ChangeTotalPrizeText(mainWindow.order.TotalPrize);
        }
        private void ChangeTotalPrizeText(float price)
        {
            TotalPrizeLabel.Text = string.Format("Total prize: {0} PLN", price.ToString());
        }
        private void AddItemsToSummary(ObservableCollection<MenuItem> items)
        {
            foreach(MenuItem item in items)
            {
                OrderList.Items.Add(item);
            }
        }
        
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.order.WriteToFile();
            ClearOrder(mainWindow);
            Hide();
        }
        private void ClearOrder(MainWindow mainWindow)
        {
            mainWindow.order.ItemsInBasket.Clear();
            mainWindow.BasketList.Items.Clear();
            mainWindow.OrderPanel.Visibility = Visibility.Collapsed;
            mainWindow.EmptyLabel.Visibility = Visibility.Visible;
            OrderList.Items.Clear();
            ChangeTotalPrizeText(mainWindow.order.TotalPrize);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Clear();
            Hide();
        }
    }
}
