namespace Pizzeria
{
    public class MenuItem
    {
        public string Name { get; set; }
        readonly float BasePrize = 15;
        public float Prize { get; set; }
        public enum Size { Small, Medium, Large }
        public float CurrentPrize { get; set; }

        public void SetCurrentPrize()
        {
            //ustawienie ceny przedmiotu w zależności od rozmiaru
        }
    }
}
