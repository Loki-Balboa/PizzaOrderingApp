﻿using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;

            pizzaWindow = new CreatePizzaWindow();
            pizzaWindow.Hide();
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            pizzaWindow.Close();
        }

        // Sposob nr 1
        public void GetPizza(/*tu moze byc pizza jako argument*/)
        {
            // tu robisz co chcesz
        }

        // Sposob nr 2
        public static void Test()
        {
            // z tym, ze tu masz dostep jedynie do statycznych rzeczy z klasy
        }
    }
}
