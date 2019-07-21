using System.Collections.Generic;

namespace Pizzeria
{
    public class Order
    {
        public List<MenuItem> ItemsInBasket { get; set; }
        public int Number { get; set; }

        public Order()
        {
            ItemsInBasket = new List<MenuItem>();
        }
    }
}
