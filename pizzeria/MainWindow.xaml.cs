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
        private readonly OrderSummary orderSummary;

        public MainWindow()
        {
            InitializeComponent();

            orderSummary = new OrderSummary();
            orderSummary.Hide();

            ItemsInMenu.ItemsSource = menu.Pizzas;
        }

        public void AddPizza(Pizza pizza)
        {
            if (basket.ItemsInBasket.Count == 0) EmptyLabel.Visibility = Visibility.Collapsed;
            basket.ItemsInBasket.Add(pizza);
            BasketList.Items.Add(pizza);
            ItemsInMenu.UnselectAll();
            if (!OrderPanel.IsVisible) OrderPanel.Visibility = Visibility.Visible;
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if(ItemsInMenu.SelectedItem != null)
            {
                AddPizza((Pizza)ItemsInMenu.SelectedItem);
            }
        }

        private void RemoveFromBasket_Click(object sender, RoutedEventArgs e)
        {
            if(BasketList.SelectedItem != null)
            {
                basket.ItemsInBasket.Remove((Pizza)BasketList.SelectedItem);
                BasketList.Items.Remove(BasketList.SelectedItem);
                BasketList.UnselectAll();
                if (basket.ItemsInBasket.Count == 0)
                {
                    OrderPanel.Visibility = Visibility.Collapsed;
                    EmptyLabel.Visibility = Visibility.Visible;
                }
            }
            
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
