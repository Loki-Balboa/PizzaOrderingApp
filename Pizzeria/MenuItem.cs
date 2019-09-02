namespace Pizzeria
{
    public class MenuItem
    {
        public string Name { get; set; }
        public float BasePrice { get; set; }
        public float CurrentPrice { get; set; }
        public float PrizeSmall { get => BasePrice * 0.75f; }
        public float PrizeMedium { get => BasePrice; }
        public float PrizeLarge { get => BasePrice * 1.25f; }
        public enum Size { Small, Medium, Large }
        public MenuItem(string name)
        {
            this.Name = name;
        }
        public MenuItem(string name, float basePrice)
        {
            this.Name = name;
            this.BasePrice = basePrice;
        }
        public void SetSize(MenuItem.Size size)
        {
            switch (size)
            {
                case Size.Small:
                    {
                        CurrentPrice = PrizeSmall;
                        break;
                    }
                case Size.Medium:
                    {
                        CurrentPrice = PrizeMedium;
                        break;
                    }
                case Size.Large:
                    {
                        CurrentPrice = PrizeLarge;
                        break;
                    }
            }
        }
    }
}
