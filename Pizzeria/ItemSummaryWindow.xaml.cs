using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for ItemSummaryWindow.xaml
    /// </summary>
    public partial class ItemSummaryWindow : Window
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        public bool IsMouseIn { get; set; }
        public ItemSummaryWindow(string name ,List<Ingredient> ingredients)
        {
            InitializeComponent();
            this.Name = name;
            this.ingredients = ingredients;
            SetWindowOrigin();
            IngredientsList.ItemsSource = ingredients;
            Show();
        }

        private void SetWindowOrigin()
        {
            Point mouseCoord = GetMouseCoordinates();
            Top = mouseCoord.Y;
            Left = mouseCoord.X;
        }

        private Point GetMouseCoordinates()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            return Application.Current.MainWindow.PointToScreen(Mouse.GetPosition(Application.Current.MainWindow));
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            IsMouseIn = true;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            IsMouseIn = false;
        }
    }
}
