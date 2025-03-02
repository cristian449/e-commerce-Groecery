using System.ComponentModel.DataAnnotations.Schema;

namespace FruitVegBasket.Api.Data.Entities
{
    [Table(nameof(Category))]
    public class Category
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public short ParentId { get; set; }

        public string? Credit { get; set; }


    }
}