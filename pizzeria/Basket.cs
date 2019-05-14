using System.Collections.Generic;

namespace Pizzeria
{
    public class Basket
    {
        public List<Pizza> ItemsInBasket { get; set; }

        public Basket()
        {
            ItemsInBasket = new List<Pizza>();
        }
        public void AddItem()
        {
            //ItemsInBasket.Add();
        }
    }
}
