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
            var myPizza = new Pizza("Custom Pizza", new List<Ingredient> { menu.Ingredients[0], menu.Ingredients[1] });
            basket.ItemsInBasket.Add(myPizza);
            Basket.Items.Add(myPizza);
            pizzaWindow.Show();
            //Basket.ItemsSource = basket.ItemsInBasket;
        }
    }
}
