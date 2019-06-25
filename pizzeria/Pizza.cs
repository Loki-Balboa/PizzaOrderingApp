using System.Collections.Generic;

namespace Pizzeria
{
    public class Pizza
    {
        public string Name { get; }
        public List<Ingredient> Ingredients{ get; set; }
        public enum Size { Small, Medium, Large }
        public float BasePrize { get; set; }
        public float Prize { get; set; }

        public Pizza(string name, List<Ingredient> ingredients)
        {
            this.Name = name;
            this.Ingredients = ingredients;
            Prize = 15;

            foreach (Ingredient ingredient in Ingredients)
            {
                Prize += ingredient.Prize;
            }
        }
        public Pizza(string name, List<Ingredient> ingredients, float prize)
        {
            this.Name = name;
            this.Ingredients = ingredients;
            this.Prize = prize;
        }
    }
}
