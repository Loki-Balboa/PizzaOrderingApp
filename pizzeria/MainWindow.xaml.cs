using System.ComponentModel;
using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Basket basket = new Basket();
        public Menu menu = new Menu();
        private CreatePizzaWindow pizzaWindow;
        private OrderSummary orderSummary;

        public MainWindow()
        {
            InitializeComponent();

            orderSummary = new OrderSummary();
            orderSummary.Hide();

            ItemsInMenu.ItemsSource = menu.Pizzas;
        }

        public void GetPizza(Pizza pizza)
        {
            basket.ItemsInBasket.Add(pizza);
            BasketList.Items.Add(pizza);
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if(ItemsInMenu.SelectedItem != null)
            {
                basket.ItemsInBasket.Add((Pizza)ItemsInMenu.SelectedItem);
                BasketList.Items.Add(ItemsInMenu.SelectedItem);
                ItemsInMenu.UnselectAll();
                if (!BasketPanel.IsVisible) BasketPanel.Visibility = Visibility.Visible;
            }
        }

        private void RemoveFromBasket_Click(object sender, RoutedEventArgs e)
        {
            basket.ItemsInBasket.Remove((Pizza)BasketList.SelectedItem);
            BasketList.Items.Remove(BasketList.SelectedItem);
            BasketList.UnselectAll();
            if(basket.ItemsInBasket.Count == 0) BasketPanel.Visibility = Visibility.Collapsed;
        }

        private void CreateCustomPizza_Click(object sender, RoutedEventArgs e)
        {  
            if(ExtensionMethod.IsNull(pizzaWindow))
            {
                pizzaWindow = new CreatePizzaWindow();
            }
            pizzaWindow.Show();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            orderSummary.GetOrder();
            orderSummary.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            App.Current.Shutdown();
        }
    }
}
