using System.Collections.Generic;

namespace Pizzeria
{
    public class Pizza
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients{ get; set; }
        public enum Size { Small, Medium, Large }
        public float Prize { get; private set; }

        public Pizza(string name, List<Ingredient> ingredients)
        {
            Name = name;
            this.Ingredients = ingredients;
            Prize = 15;
            foreach (var ingredient in Ingredients)
            {
                Prize += ingredient.Prize;
            }
        }
    }
}
