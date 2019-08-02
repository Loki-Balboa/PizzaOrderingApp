using System.Windows;
using System.Collections.Generic;
using System;

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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(IngredientsList.SelectedItem != null)
            {
                ingredients.Add((Ingredient)IngredientsList.SelectedItem);
                SelectedIngredientsList.Items.Add(IngredientsList.SelectedItem);
                IngredientsList.UnselectAll();
                if (!SelectedIngredientsPanel.IsVisible) SelectedIngredientsPanel.Visibility = Visibility.Visible;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ingredients.Remove((Ingredient)SelectedIngredientsList.SelectedItem);
            SelectedIngredientsList.Items.Remove(SelectedIngredientsList.SelectedItem);
            SelectedIngredientsList.UnselectAll();
            if (ingredients.Count == 0) SelectedIngredientsPanel.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CreatePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            if(ingredients.Count == 0)
            {
                MessageBoxResult noIngredients = MessageBox.Show("List of ingredients is empty. Choose some ingredients first!","No ingredients!");
            }
            else
            {
                MenuItem customPizza = new Pizza("Custom Pizza", ingredients);
                ChooseSizeWindow chooseSizeWindow = new ChooseSizeWindow(new MenuItem(customPizza.Name, customPizza.BasePrice));
                chooseSizeWindow.Owner = this;
                Nullable<bool> chooseResult = chooseSizeWindow.ShowDialog();
                ingredients.Clear();
                SelectedIngredientsList.Items.Clear();
                SelectedIngredientsPanel.Visibility = Visibility.Collapsed;
                Hide();
            }
        }
    }
}
