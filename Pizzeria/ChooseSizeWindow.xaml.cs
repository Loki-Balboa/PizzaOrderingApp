using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for ChooseSizeWindow.xaml
    /// </summary>
    public partial class ChooseSizeWindow : Window
    {
        public MenuItem Item{ get; set; }
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public ChooseSizeWindow(MenuItem item)
        {
            InitializeComponent();
            Show();
            this.Item = item;
        }

        private void SmallSizeButton_Click(object sender, RoutedEventArgs e)
        {
            Item.SetSize(MenuItem.Size.Small);
            mainWindow.AddItem(Item);
            Close();
        }

        private void MediumSizeButton_Click(object sender, RoutedEventArgs e)
        {
            Item.SetSize(MenuItem.Size.Medium);
            mainWindow.AddItem(Item);
            Close();
        }

        private void LargeSizeButton_Click(object sender, RoutedEventArgs e)
        {
            Item.SetSize(MenuItem.Size.Large);
            mainWindow.AddItem(Item);
            Close();
        }
    }
}
