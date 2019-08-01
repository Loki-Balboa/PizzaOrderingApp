namespace Pizzeria
{
    public class Drink : MenuItem
    {
        public Drink(string name, float prize) : base(name)
        {
            this.BasePrice = prize;
        }
    }
}
