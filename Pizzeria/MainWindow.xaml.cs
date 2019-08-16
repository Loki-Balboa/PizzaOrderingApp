using System;
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
        private object currentlySelectedItem;
        private CreatePizzaWindow createPizzaWindow;
        private OrderSummaryWindow orderSummaryWindow;

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
            Nullable<bool> chooseResult = chooseSizeWindow.ShowDialog();
        }

        private void RemoveFromBasket_Click(object sender, RoutedEventArgs e)
        {
            if(BasketList.SelectedItem != null)
            {
                order.ItemsInBasket.Remove((MenuItem)BasketList.SelectedItem);
                BasketList.UnselectAll();
                if (order.ItemsInBasket.Count == 0)
                {
                    HideBasket();
                }
            }
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
            Nullable<bool> createPizzaResult = createPizzaWindow.ShowDialog();
        }

        private void DrinksInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PizzasInMenuList.SelectedItems.Clear();
            currentlySelectedItem = DrinksInMenuList.SelectedItem;
        }

        private void PizzasInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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
                Nullable<bool> orderResult = orderSummaryWindow.ShowDialog();
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Current.Shutdown();
        }

        //private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    itemSummaryWindow = new ItemSummaryWindow();
        //    foreach(object row in PizzasInMenuList.Items)
        //    {
        //    }
        //}

        //private void TextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    if(!itemSummaryWindow.isMouseIn)
        //    {
        //        System.Threading.Thread.Sleep(500);
        //        itemSummaryWindow.Close();
        //    }
        //}
        
    }
}
