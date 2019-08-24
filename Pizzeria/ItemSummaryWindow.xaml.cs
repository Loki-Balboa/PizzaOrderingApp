using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for ItemSummaryWindow.xaml
    /// </summary>
    public partial class ItemSummaryWindow : Window
    {
        private List<Ingredient> ingredients;
        public bool isMouseIn;
        public ItemSummaryWindow(List<Ingredient> ingredients)
        {
            InitializeComponent();
            this.ingredients = ingredients;
            Point mouseCoord = GetMouseCoordinates();
            Top = mouseCoord.Y;
            Left = mouseCoord.X;
            Show();
            IngredientsList.ItemsSource = ingredients;
        }
        private Point GetMouseCoordinates()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            return Application.Current.MainWindow.PointToScreen(Mouse.GetPosition(Application.Current.MainWindow));
        }
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            isMouseIn = true;
        }
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            isMouseIn = false;
        }
    }
}
