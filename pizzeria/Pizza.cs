using System.Collections.Generic;

namespace Pizzeria
{
    public class Pizza : MenuItem
    {
        public List<Ingredient> Ingredients{ get; set; }
        public Pizza(string name, List<Ingredient> ingredients) : base(name)
        {
            this.Ingredients = ingredients;
            BasePrice = 15;

            foreach (Ingredient ingredient in Ingredients)
            {
                BasePrice += ingredient.Price;
            }
        }
        public Pizza(string name, List<Ingredient> ingredients, float prize) : base(name)
        {
            this.Ingredients = ingredients;
            this.BasePrice = prize;
        }
        
    }
}
