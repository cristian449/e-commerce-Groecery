using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FruitVegBasket.Api.Data.Entities
{
    [Table(nameof(Offer))]
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        public string BgColor { get; set; }

        public bool isActive { get; set; }

        public Offer(int id, string title, string description, string bgColor, string code) : this()
        {
            Id = id;
            Title = title;
            Description = description;
            BgColor = bgColor;
            Code = code;
        }

        public Offer()
        {
        }

        private static readonly string[] _lightColors = new string[]
        {
           "#e1f1e7", "#dad1f9", "#ffff00", "#d0f200", "#e28083", "#7fbdc7", "#ea978d"
        };

        private static string RandomColor => _lightColors.OrderBy(c => Guid.NewGuid()).First();
        public static IEnumerable<Offer> GetInitialOffers() =>
            new List<Offer>
        {
            new Offer(1, "Upto 30% off", "Enjoy upto 30% off on all fruits", RandomColor, "Frt30"),
            new Offer(2, "Buy 1 Get 1 Free", "Buy one get one free on selected vegetables", RandomColor, "VegB1G1"),
            new Offer(3, "20% off on Dairy", "Get 20% off on all dairy products", RandomColor, "Dairy20"),
            new Offer(4, "Special Discount", "Special discount on eggs and meat", RandomColor, "EggMeat10")
        };
    }
}