using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FruitVegBasket.Models
{
    public class Category
    {
        public Category(short id, string name, short parentId, string image, string credit)
        {
            Id = id;
            Name = name;
            Image = image;
            ParentId = parentId;
            //Credit = credit;
        }

        public short Id { get; set; }

        public string Name { get; set; }

        //public string Image { get; set; }

        private string _image;

        public string Image
        {
            get => _image;
            set
            {
                _image = $"https://localhost:5503/images/{value}"; //May be a probem here, as i don have the images yet so i'll fix this later, part 7 12:36 of the video
                                                                   //Another thing, i can get the images from Abhay's github, later 
            }
        }

        public short ParentId { get; set; }

        public string? Credit { get; set; }

        public bool IsMainCategory => ParentId == 0;

        public string ImageUrl => $"https://localhost:5503/images/{Image}";
    }


}