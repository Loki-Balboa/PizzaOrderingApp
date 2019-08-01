namespace Pizzeria
{
    public class Ingredient
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public enum Size { Small, Medium, Large }

        public Ingredient(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
