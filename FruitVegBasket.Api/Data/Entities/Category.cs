using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitVegBasket.Api.Data.Entities
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public short ParentId { get; set; }

        public string? Credit { get; set; }

        public Category(short id, string name, short parentId, string image, string credit) : this()
        {
            Id = id;
            Name = name;
            Image = image;
            ParentId = parentId;
            Credit = credit;
        }

        public Category()
        {

        }

        public static IEnumerable<Category> GetInitialCategories()
        {
            var categories = new List<Category>();

            var fruits = new List<Category>
            {
                new (1, "Apple", 0, "apple.jpg", "Photo By <a href=\""),
                new (2, "Banana", 0, "banana.jpg", "Photo By <a href=\""),
            };
            categories.AddRange(fruits);

            var vegetables = new List<Category>
            {
                new (3, "Carrot", 0, "carrot.jpg", "Photo By <a href=\""),
                new (4, "Broccoli", 0, "broccoli.jpg", "Photo By <a href=\""),
            };
            categories.AddRange(vegetables);

            var dairy = new List<Category>
            {
                new (5, "Milk", 0, "milk.jpg", "Photo By <a href=\""),
                new (6, "Cheese", 0, "cheese.jpg", "Photo By <a href=\""),
            };
            categories.AddRange(dairy);

            var eggsmeat = new List<Category>
            {
                new (7, "Eggs", 0, "eggs.jpg", "Photo By <a href=\""),
                new (8, "Chicken", 0, "chicken.jpg", "Photo By <a href=\""),
            };
            categories.AddRange(eggsmeat);

            return categories;
        }
    }
}