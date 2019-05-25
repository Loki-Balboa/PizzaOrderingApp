﻿using System.ComponentModel;
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
        public Pizza customPizza = new Pizza("Custom Pizza", new List<Ingredient>()); 

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
            customPizza.Ingredients.Add((Ingredient)IngredientsList.SelectedItem);
            SelectedIngredientsList.Items.Add(IngredientsList.SelectedItem);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            customPizza.Ingredients.Remove((Ingredient)SelectedIngredientsList.SelectedItem);
            SelectedIngredientsList.Items.Remove(SelectedIngredientsList.SelectedItem);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CreatePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            // 1 sposob
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GetPizza();

            // 2 sposob - metoda statyczna
            MainWindow.Test();
            Hide();
        }
    }
}
