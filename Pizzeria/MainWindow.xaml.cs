﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order order = new Order();
        public Menu menu = new Menu();
        private object currentSelection;
        private CreatePizzaWindow createPizzaWindow;
        private OrderSummaryWindow orderSummaryWindow;
        private ItemSummaryWindow itemSummaryWindow;

        public MainWindow()
        {
            InitializeComponent();
            PizzasInMenuList.ItemsSource = menu.Pizzas;
            DrinksInMenuList.ItemsSource = menu.Drinks;
            BasketList.ItemsSource = order.ItemsInBasket;
        }

        public void AddItem(MenuItem item)
        {
            if (order.ItemsInBasket.Count == 0) EmptyLabel.Visibility = Visibility.Collapsed;
            order.ItemsInBasket.Add(item);
            if (!OrderPanel.IsVisible) OrderPanel.Visibility = Visibility.Visible;
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if(currentSelection != null)
            {
                MenuItem item = (MenuItem)currentSelection;
                ChooseSizeWindow chooseSizeWindow = new ChooseSizeWindow(new MenuItem(item.Name, item.BasePrice));
                chooseSizeWindow.Owner = this;
                Nullable<bool> chooseResult = chooseSizeWindow.ShowDialog();
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
            createPizzaWindow = new CreatePizzaWindow();
            createPizzaWindow.Owner = this;
            Nullable<bool> createPizzaResult = createPizzaWindow.ShowDialog();
        }

        private void DrinksInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PizzasInMenuList.SelectedItems.Clear();
            currentSelection = DrinksInMenuList.SelectedItem;
        }

        private void PizzasInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DrinksInMenuList.SelectedItems.Clear();
            currentSelection = PizzasInMenuList.SelectedItem;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            if (orderSummaryWindow == null)
            {
                orderSummaryWindow = new OrderSummaryWindow();
                orderSummaryWindow.Owner = this;
            }
            orderSummaryWindow.GetOrder();
            Nullable<bool> orderResult = orderSummaryWindow.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            App.Current.Shutdown();
        }

        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            itemSummaryWindow = new ItemSummaryWindow();
        }

        private void TextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            itemSummaryWindow.Close();
        }
        
    }
}
