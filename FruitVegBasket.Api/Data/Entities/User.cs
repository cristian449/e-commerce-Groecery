using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FruitVegBasket.Api.Constants;
using Microsoft.Identity.Client;

namespace FruitVegBasket.Api.Data.Entities
{

    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public short RoleId { get; set; }
        //We should not have plain password this is just for simplicity and demonstration purposes
        public string Password { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public static IEnumerable<User> GetInitialUsers() =>
            new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Cristian Pent",
                    Email = "exampleemail@gmail.com",
                    Mobile = "1234567890",
                    Password = "123456678",
                    RoleId = DatabaseConstants.Roles.Admin.Id
                }
            };
    }
}