namespace Pizzeria
{
    public class Ingredient
    {
        public string Name { get; set; }
        public float Prize { get; set; }
        public enum Size { Small, Medium, Large }

        public Ingredient(string name, float prize)
        {
            Name = name;
            Prize = prize;
        }
    }
}
