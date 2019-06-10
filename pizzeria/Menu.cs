using System;
using System.Collections.Generic;
using System.IO;

namespace Pizzeria
{
    public class Menu
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Pizza> Pizzas { get; set; }
        //public List<Drink> Drinks { get; set; }

        public Menu()
        {
            Ingredients = new List<Ingredient>();
            ReadFromFile();
            Ingredient cheese = new Ingredient("Cheese", 3);
            Ingredient salami = new Ingredient("Salami", 4);
            Ingredient mushrooms = new Ingredient("Mushrooms", 2);
            Pizza margharita = new Pizza("Margharita", new List<Ingredient> { cheese, salami });
            Pizza capriciosa = new Pizza("Capriciosa", new List<Ingredient> { cheese, mushrooms });
            Pizzas = new List<Pizza> { margharita, capriciosa};
        }

        public void AddPizza()
        {
            //Pizzas.Add(new Pizza());
        }

        public void RemovePizza()
        {
            //Pizzas.Remove();
        }

        public void AddIngredient()
        {
            //Ingredients.Add(new Ingredient());
        }

        public void RemoveIngredient()
        {
            //Ingredients.Remove();
        }

        private void ReadFromFile()
        {
            string[] ingredients = File.ReadAllLines(@"C:\Users\plubs\source\repos\Pizzeria\ingredients.txt");
            string[] pizzas= File.ReadAllLines(@"C:\Users\plubs\source\repos\Pizzeria\menu.txt");
            foreach(string ingredientDescription in ingredients)
            {
                string[] ingredient = ingredientDescription.Split(';');
                this.Ingredients.Add(new Ingredient(ingredient[0], (float)Convert.ToDouble(ingredient[1])));
            }
        }
    }
}
