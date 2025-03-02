namespace FruitVegBasket.Models
{
    public class Offer
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public Color BgColor { get; set; }

        public Offer(string title, string description, Color bgColor, string code)
        {
            Title = title;
            Description = description;
            BgColor = bgColor;
            Code = code;
        }


        private static readonly string[] _lightColors = new string[]
        {
           "#e1f1e7", "#dad1f9", "#ffff00", "#d0f200", "#e28083", "#7fbdc7", "#ea978d" 
        };

        private static Color RandomColor => Color.FromHex(_lightColors.OrderBy(c => Guid.NewGuid()).First());
        public static IEnumerable<Offer> GetOffers()
        {
            yield return new Offer("Upto 30% off", "Enjoy upto 30% off on all fruits", RandomColor, "Frt30");
            yield return new Offer("Buy 1 Get 1 Free", "Buy one get one free on selected vegetables", RandomColor, "VegB1G1");
            yield return new Offer("20% off on Dairy", "Get 20% off on all dairy products", RandomColor, "Dairy20");
            yield return new Offer("Special Discount", "Special discount on eggs and meat", RandomColor, "EggMeat10");
        }


    }
}