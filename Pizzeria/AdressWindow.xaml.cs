using System.Reflection;
using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for AdressWindow.xaml
    /// </summary>
    public partial class AdressWindow : Window
    {
        public Adress Adress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string StreetPt2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }

        public AdressWindow()
        {
            InitializeComponent();
            Adress = new Adress();
            this.DataContext = Adress;
        }
        
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (Adress.IsComplete())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                DialogResult = false;
                MessageBoxResult adressInvalid = MessageBox.Show("Adress is not complete", "Adress invalid");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
