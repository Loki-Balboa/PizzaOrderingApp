using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
            pizzaWindow = new CreatePizzaWindow();
            pizzaWindow.Hide();
            MenuPositions.ItemsSource = menu.Pizzas;            
        }

        private void CreateYourOwnPizza_Click(object sender, RoutedEventArgs e)
        {
            pizzaWindow.Show();
        }

        //public void AddPizzaToBasket(Pizza pizza)
        //{
        //    basket.ItemsInBasket.Add(pizza);
        //    BasketList.Items.Add(pizza);
        //}
    }
}
