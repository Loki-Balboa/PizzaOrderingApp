using Pizzeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeria
{
    public class Menu
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Pizza> Pizzas { get; set; }
        //public List<Drink> Drinks { get; set; }

        public Menu()
        {
            var cheese = new Ingredient("Cheese", 3);
            var salami = new Ingredient("Salami", 4);
            var mushrooms = new Ingredient("Mushrooms", 2);
            Ingredients = new List<Ingredient> { cheese, salami, mushrooms };
            var margharita = new Pizza("Margharita", new List<Ingredient> { cheese, salami });
            var capriciosa = new Pizza("Capriciosa", new List<Ingredient> { cheese, mushrooms });
            Pizzas = new List<Pizza> { margharita, capriciosa};
        }
        //tutaj polimorfizm
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
