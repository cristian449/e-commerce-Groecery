using FruitVegBasket.Enumeration;

namespace FruitVegBasket.Models
{
    public class Order
    {
        public long Id { get; set; }

        public IEnumerable<CartItem> Items { get; set; } = Enumerable.Empty<CartItem>();

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal TotalAmount => Items.Sum(i => i.Amount);

        public OrderStatus Status { get; set; } = OrderStatus.Placed;

        public Color StatusColor => _orderStatusColorsMap[Status];

        private static readonly IReadOnlyDictionary<OrderStatus, Color> _orderStatusColorsMap =
            new Dictionary<OrderStatus, Color>
            {
                [OrderStatus.Placed] = Color.FromRgb(255, 255, 0), // Yellow
                [OrderStatus.Confirmed] = Color.FromRgb(0, 0, 255), // Blue
                [OrderStatus.Delivered] = Color.FromRgb(0, 128, 0), // Green
                [OrderStatus.Cancelled] = Color.FromRgb(255, 0, 0), // Red
            };

    }


}