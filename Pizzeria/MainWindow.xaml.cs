using System;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Diagnostics;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order order = new Order();
        public Menu menu = new Menu();
        private object currentlySelectedItem;
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

        public void AddItemToBasket(MenuItem item)
        {
            if (order.ItemsInBasket.Count == 0) EmptyLabel.Visibility = Visibility.Collapsed;
            order.ItemsInBasket.Add(item);
            if (!OrderPanel.IsVisible) OrderPanel.Visibility = Visibility.Visible;
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if(currentlySelectedItem != null)
            {
                ChooseSize(currentlySelectedItem);
            }
        }

        private void ChooseSize(object currentlySelectedItem)
        {
            MenuItem item = (MenuItem)currentlySelectedItem;
            ChooseSizeWindow chooseSizeWindow = new ChooseSizeWindow(new MenuItem(item.Name, item.BasePrice));
            chooseSizeWindow.Owner = this;
            bool? chooseResult = chooseSizeWindow.ShowDialog();
        }

        private void RemoveFromBasket_Click(object sender, RoutedEventArgs e)
        {
            if(BasketList.SelectedItem != null)
            {
                order.ItemsInBasket.Remove((MenuItem)BasketList.SelectedItem);
                BasketList.UnselectAll();
            }
            if (order.ItemsInBasket.Count == 0) HideBasket();
        }

        private void HideBasket()
        {
            OrderPanel.Visibility = Visibility.Collapsed;
            EmptyLabel.Visibility = Visibility.Visible;
        }

        private void CreateCustomPizza_Click(object sender, RoutedEventArgs e)
        {  
            createPizzaWindow = new CreatePizzaWindow();
            createPizzaWindow.Owner = this;
            bool? createPizzaResult = createPizzaWindow.ShowDialog();
        }

        private void DrinksInMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PizzasInMenuList.SelectedItems.Clear();
            currentlySelectedItem = DrinksInMenuList.SelectedItem;
        }

        private void PizzasInMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrinksInMenuList.SelectedItems.Clear();
            currentlySelectedItem = PizzasInMenuList.SelectedItem;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            FillAdressForm();
            if (order.Adress != null)
            {
                order.CalculateTotalPrize();
                orderSummaryWindow = new OrderSummaryWindow(order);
                orderSummaryWindow.Owner = this;
                bool? orderResult = orderSummaryWindow.ShowDialog();
            }
        }

        private void FillAdressForm()
        {
            AdressWindow adressWindow = new AdressWindow();
            adressWindow.Owner = this;
                if(adressWindow.ShowDialog() == true)
            {
                order.Adress = adressWindow.Adress;
            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            //  TODO: Check if mouse not moves for given time before showing item summary
            ShowItemSummary();
        }

        private void ShowItemSummary()
        {
            Point point = Mouse.GetPosition(this);
            HitTestResult result = VisualTreeHelper.HitTest(this, point);
            Pizza pizza = MatchHitResultToPizza(result);
            if(itemSummaryWindow == null ||
                (itemSummaryWindow!=null && pizza.Name != itemSummaryWindow.ItemName))
            {
                itemSummaryWindow = new ItemSummaryWindow(pizza.Name, pizza.Ingredients);
            }
        }

        private Pizza MatchHitResultToPizza(HitTestResult result)
        {
            DependencyObject obj = result.VisualHit;
            TextBlock textBlock = obj as TextBlock;
            foreach (Pizza pizza in menu.Pizzas)
            {
                if (pizza.Name == textBlock.Text)
                {
                    return pizza;
                }
            }
            return null;
        }

        private void TextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(itemSummaryWindow != null && !itemSummaryWindow.IsMouseOver)
            {
                System.Threading.Thread.Sleep(1000);
                itemSummaryWindow.ItemName = null;
                itemSummaryWindow.Close();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Current.Shutdown();
        }
    }
}
