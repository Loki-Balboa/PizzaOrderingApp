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
            this.Name = name;
            this.Ingredients = ingredients;
            Prize = 15;

            foreach (Ingredient ingredient in Ingredients)
            {
                Prize += ingredient.Prize;
            }

        }

        private void CalculatePrize(Pizza.Size size)
        {
            switch(size)
            {
                case Size.Medium:
                    Prize *= (float)1.25;
                    break;
                case Size.Large:
                    Prize *= (float)1.5;
                    break;
                default:
                    break;
            }
        }
    }
}
