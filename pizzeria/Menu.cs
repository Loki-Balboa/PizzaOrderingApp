using System.Collections.Generic;

namespace Pizzeria
{
    public class Menu
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Pizza> Pizzas { get; set; }
        //public List<Drink> Drinks { get; set; }

        public Menu()
        {
            Ingredient cheese = new Ingredient("Cheese", 3);
            Ingredient salami = new Ingredient("Salami", 4);
            Ingredient mushrooms = new Ingredient("Mushrooms", 2);
            Ingredients = new List<Ingredient> { cheese, salami, mushrooms };
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
    }
}
