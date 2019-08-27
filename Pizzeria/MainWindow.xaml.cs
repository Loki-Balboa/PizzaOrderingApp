using System;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order order = new Order();
        public Menu menu = new Menu();
        private object CurrentlySelectedItem;
        private CreatePizzaWindow CreatePizzaWindow;
        private OrderSummaryWindow OrderSummaryWindow;
        private ItemSummaryWindow ItemSummaryWindow;

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
            if(CurrentlySelectedItem != null)
            {
                ChooseSize(CurrentlySelectedItem);
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
            CreatePizzaWindow = new CreatePizzaWindow();
            CreatePizzaWindow.Owner = this;
            Nullable<bool> createPizzaResult = CreatePizzaWindow.ShowDialog();
        }

        private void DrinksInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PizzasInMenuList.SelectedItems.Clear();
            CurrentlySelectedItem = DrinksInMenuList.SelectedItem;
        }

        private void PizzasInMenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DrinksInMenuList.SelectedItems.Clear();
            CurrentlySelectedItem = PizzasInMenuList.SelectedItem;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            FillAdressForm();
            if (order.Adress != null)
            {
                order.CalculateTotalPrize();
                OrderSummaryWindow = new OrderSummaryWindow(order);
                OrderSummaryWindow.Owner = this;
                Nullable<bool> orderResult = OrderSummaryWindow.ShowDialog();
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

        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //if (MouseNotMoves(1000))
            //{
                ShowItemSummary();
            //}
        }

        private void ShowItemSummary()
        {
            Point point = System.Windows.Input.Mouse.GetPosition(this);
            HitTestResult result = VisualTreeHelper.HitTest(this, point);
            Pizza pizza = MatchHitResultToPizza(result);
            if (ItemSummaryWindow != null)
            {
                ItemSummaryWindow.Close();
                if (pizza.Name != ItemSummaryWindow.Name)
                {
                    ItemSummaryWindow = new ItemSummaryWindow(pizza.Name, pizza.Ingredients);
                }
            }
            else
            {
                ItemSummaryWindow = new ItemSummaryWindow(pizza.Name, pizza.Ingredients);
            }
        }

        private bool MouseNotMoves(int time)
        {
            Point currentMouseCoord = System.Windows.Input.Mouse.GetPosition(this);
            TimeSpan timeSpan = new TimeSpan(0,0,0,0,0);
            DateTime start = DateTime.Now;
            while (timeSpan.TotalMilliseconds <= time)
            {
                timeSpan = DateTime.Now - start;
                Point newMouseCoord = System.Windows.Input.Mouse.GetPosition(this);
                if (currentMouseCoord != newMouseCoord) start = DateTime.Now;
                currentMouseCoord = newMouseCoord;
            }
            return true;
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
            if(ItemSummaryWindow != null && !ItemSummaryWindow.IsMouseOver)
            {
                System.Threading.Thread.Sleep(1000);
                ItemSummaryWindow.Name = null;
                ItemSummaryWindow.Close();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Current.Shutdown();
        }
    }
}
