using System.Collections.Generic;

namespace Pizzeria
{
    public class Basket
    {
        public List<MenuItem> ItemsInBasket { get; set; }

        public Basket()
        {
            ItemsInBasket = new List<MenuItem>();
        }
        public void AddItem()
        {
            //ItemsInBasket.Add();
        }
    }
}
