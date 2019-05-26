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
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;

            pizzaWindow = new CreatePizzaWindow();
            pizzaWindow.Hide();
            orderSummary = new OrderSummary();
            orderSummary.Hide();

            ItemsInMenu.ItemsSource = menu.Pizzas;            
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            basket.ItemsInBasket.Add((Pizza)ItemsInMenu.SelectedItem);
            BasketList.Items.Add(ItemsInMenu.SelectedItem);
        }

        private void RemoveFromBasket_Click(object sender, RoutedEventArgs e)
        {
            basket.ItemsInBasket.Remove((Pizza)BasketList.SelectedItem);
            BasketList.Items.Remove(BasketList.SelectedItem);
        }

        private void CreateYourOwnPizza_Click(object sender, RoutedEventArgs e)
        {  
            pizzaWindow.Show();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            orderSummary.GetOrder();
            orderSummary.Show();
        }
        
        public void GetPizza(Pizza pizza)
        {
            basket.ItemsInBasket.Add(pizza);
            BasketList.Items.Add(pizza);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            pizzaWindow.Close();
            orderSummary.Close();
        }
    }
}
