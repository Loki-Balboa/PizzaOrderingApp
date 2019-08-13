using System.Windows;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for CreatePizzaWindow.xaml
    /// </summary>
    public partial class CreatePizzaWindow : Window
    {
        private Menu menu = new Menu();
        private ObservableCollection<Ingredient> selectedIngredients = new ObservableCollection<Ingredient>();

        public CreatePizzaWindow()
        {
            InitializeComponent();
            IngredientsList.ItemsSource = menu.Ingredients;
            SelectedIngredientsList.ItemsSource = selectedIngredients;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(IngredientsList.SelectedItem != null)
            {
                selectedIngredients.Add((Ingredient)IngredientsList.SelectedItem);
                IngredientsList.UnselectAll();
                if (!SelectedIngredientsPanel.IsVisible) SelectedIngredientsPanel.Visibility = Visibility.Visible;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            selectedIngredients.Remove((Ingredient)SelectedIngredientsList.SelectedItem);
            SelectedIngredientsList.Items.Remove(SelectedIngredientsList.SelectedItem);
            SelectedIngredientsList.UnselectAll();
            if (selectedIngredients.Count == 0) SelectedIngredientsPanel.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CreatePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedIngredients.Count == 0)
            {
                MessageBoxResult noIngredients = MessageBox.Show("List of ingredients is empty. Choose some ingredients first!","No ingredients!");
            }
            else
            {
                CreatePizza();
                Close();
            }
        }
        private void CreatePizza()
        {
            MenuItem customPizza = new Pizza("Custom Pizza", new List<Ingredient>(selectedIngredients));
            ChooseSizeWindow chooseSizeWindow = new ChooseSizeWindow(new MenuItem(customPizza.Name, customPizza.BasePrice));
            chooseSizeWindow.Owner = this;
            Nullable<bool> chooseResult = chooseSizeWindow.ShowDialog();
        }
    }
}
