using System;
using System.Collections.Generic;
using System.IO;

namespace Pizzeria
{
    public class Menu
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Drink> Drinks { get; set; }

        public Menu()
        {
            Ingredients = new List<Ingredient>();
            Pizzas = new List<Pizza>();
            Drinks = new List<Drink>();
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            string currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            ReadIngredients(currentPath);
            ReadPizzas(currentPath);
            ReadDrinks(currentPath);
        }

        private void ReadIngredients(string currentPath)
        {
            string[] ingredients = File.ReadAllLines(currentPath + @"\data\ingredients.txt");
            foreach (string ingredientDescription in ingredients)
            {
                string[] ingredient = ingredientDescription.Split(';');
                this.Ingredients.Add(new Ingredient(ingredient[0], (float)Convert.ToDouble(ingredient[1])));
            }
        }

        private void ReadPizzas(string currentPath)
        {
            string[] pizzas = File.ReadAllLines(currentPath + @"\data\pizzas.txt");
            foreach (string pizzaDescription in pizzas)
            {
                string[] pizza = pizzaDescription.Split(';');

                if (string.IsNullOrEmpty(pizza[2]))
                {
                    this.Pizzas.Add(new Pizza(pizza[0], MatchIngredients(pizza)));
                }
                else
                {
                    float prize;
                    if (float.TryParse(pizza[2], out prize))
                    {
                        this.Pizzas.Add(new Pizza(pizza[0], MatchIngredients(pizza), (float)Convert.ToDouble(pizza[2])));
                    }
                    else
                    {
                        throw new Exception(string.Format("Prize in {0} in wrong format", pizza[0]));
                    }
                }
            }
        }

        private void ReadDrinks(string currentPath)
        {
            string[] drinks = File.ReadAllLines(currentPath + @"\data\drinks.txt");
            foreach (string drinkDescription in drinks)
            {
                string[] drink = drinkDescription.Split(';');
                this.Drinks.Add(new Drink(drink[0], (float)Convert.ToDouble(drink[1])));
            }
        }

        private List<Ingredient> MatchIngredients(string[] pizza)
        {
            string[] ingredientNames = pizza[1].Split(',');
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (string ingredientName in ingredientNames)
            {
                foreach (Ingredient ingredient in this.Ingredients)
                {
                    if (ingredientName.Equals(ingredient.Name))
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }
            return ingredients;
        }
    }
}
