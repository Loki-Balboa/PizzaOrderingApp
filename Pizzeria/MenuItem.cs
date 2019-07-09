namespace Pizzeria
{
    public abstract class MenuItem
    {
        public string Name { get; set; }
        public float Prize { get; set; }
        public enum Size { Small, Medium, Large }
    }
}
