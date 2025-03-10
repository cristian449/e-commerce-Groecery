﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FruitVegBasket.Api.Constants;

namespace FruitVegBasket.Api.Data.Entities
{
    [Table(nameof(Role))]
    public class Role
    {
        [Key]
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        internal static IEnumerable<Role> GetInitialRoles() =>
            new List<Role>
            {
                new Role
                {
                    Id = DatabaseConstants.Roles.Admin.Id,
                    Name = DatabaseConstants.Roles.Admin.Name
                },
                new Role
                {
                    Id = DatabaseConstants.Roles.Customer.Id,
                    Name = DatabaseConstants.Roles.Customer.Name
                }

            };
    }
}