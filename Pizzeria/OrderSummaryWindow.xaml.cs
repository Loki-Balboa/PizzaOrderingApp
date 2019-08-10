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
        readonly Order order;
        public float TotalPrice { get; set; }
        public OrderSummaryWindow(Order order)
        {
            InitializeComponent();
            this.order = order;
            OrderList.ItemsSource = order.ItemsInBasket;
            ChangeTotalPrizeText(order.TotalPrize);
        }
        private void ChangeTotalPrizeText(float price)
        {
            TotalPrizeLabel.Text = string.Format("Total prize: {0} PLN", price.ToString());
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
            mainWindow.OrderPanel.Visibility = Visibility.Collapsed;
            mainWindow.EmptyLabel.Visibility = Visibility.Visible;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
