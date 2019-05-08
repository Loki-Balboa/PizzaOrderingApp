using System.Collections.Generic;

namespace Pizzeria
{
    public class Basket
    {
        public List<object> ItemsInBasket { get; set; }

        public Basket()
        {
            ItemsInBasket = new List<object>();
        }
        public void AddItem()
        {
            //ItemsInBasket.Add();
        }
    }
}
