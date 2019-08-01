namespace Pizzeria
{
    public class MenuItem
    {
        public string Name { get; set; }
        public float BasePrice { get; set; }
        public float CurrentPrice { get; set; }
        public enum Size { Small, Medium, Large }
        public MenuItem(string name)
        {
            this.Name = name;
        }
        public void SetSize(MenuItem.Size size)
        {
            switch (size)
            {
                case Size.Small:
                    {
                        CurrentPrice = 0.75f * BasePrice;
                        break;
                    }
                case Size.Medium:
                    {
                        CurrentPrice = BasePrice;
                        break;
                    }
                case Size.Large:
                    {
                        CurrentPrice = 1.25f * BasePrice;
                        break;
                    }
            }
        }
    }
}
