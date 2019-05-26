using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for CreatePizzaWindow.xaml
    /// </summary>
    public partial class CreatePizzaWindow : Window
    {
        public Menu menu = new Menu();
        public List<Ingredient> ingredients = new List<Ingredient>();

        public CreatePizzaWindow()
        {
            InitializeComponent();
            IngredientsList.ItemsSource = menu.Ingredients;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Hide();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ingredients.Add((Ingredient)IngredientsList.SelectedItem);
            SelectedIngredientsList.Items.Add(IngredientsList.SelectedItem);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ingredients.Remove((Ingredient)SelectedIngredientsList.SelectedItem);
            SelectedIngredientsList.Items.Remove(SelectedIngredientsList.SelectedItem);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CreatePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GetPizza(new Pizza("Custom Pizza", ingredients));
            Hide();
        }
    }
}
