using System.ComponentModel;
using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order order = new Order();
        public Menu menu = new Menu();
        private CreatePizzaWindow pizzaWindow;
        private readonly OrderSummary orderSummary;

        public MainWindow()
        {
            InitializeComponent();

            orderSummary = new OrderSummary();
            orderSummary.Hide();

            PizzasInMenuList.ItemsSource = menu.Pizzas;
            DrinksInMenuList.ItemsSource = menu.Drinks;
        }

        public void AddItem(MenuItem item)
        {
            if (order.ItemsInBasket.Count == 0) EmptyLabel.Visibility = Visibility.Collapsed;
            order.ItemsInBasket.Add(item);
            BasketList.Items.Add(item);
            PizzasInMenuList.UnselectAll();
            if (!OrderPanel.IsVisible) OrderPanel.Visibility = Visibility.Visible;
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if(PizzasInMenuList.SelectedItem != null)
            {
                AddItem((MenuItem)PizzasInMenuList.SelectedItem);
            }
            else if(DrinksInMenuList.SelectedItem != null)
            {
                AddItem((MenuItem)DrinksInMenuList.SelectedItem);
            }
        }

        private void RemoveFromBasket_Click(object sender, RoutedEventArgs e)
        {
            if(BasketList.SelectedItem != null)
            {
                order.ItemsInBasket.Remove((MenuItem)BasketList.SelectedItem);
                BasketList.Items.Remove(BasketList.SelectedItem);
                BasketList.UnselectAll();
                if (order.ItemsInBasket.Count == 0)
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

        private void DrinksInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PizzasInMenuList.SelectedItems.Clear();
        }

        private void PizzasInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DrinksInMenuList.SelectedItems.Clear();
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
