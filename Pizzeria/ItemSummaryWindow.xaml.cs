using Pizzeria;
using pizzeria;
using System.Collections.Generic;
using System.Windows;

namespace pizzeria
{
    /// <summary>
    /// Interaction logic for ItemSummaryWindow.xaml
    /// </summary>
    public partial class ItemSummaryWindow : Window
    {
        private List<Ingredient> ingredients;
        public ItemSummaryWindow()
        {
            InitializeComponent();
            //Top = System.
            IngredientsList.ItemsSource = ingredients;
            Show();
        }
    }
}
