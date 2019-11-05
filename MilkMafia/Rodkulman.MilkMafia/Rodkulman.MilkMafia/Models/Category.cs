using System;
using System.Collections.Generic;
using System.Text;

namespace Rodkulman.MilkMafia.Models
{
    public class Category
    {
        public static Category All { get; } = new Category() { Name = "All" };

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageId { get; set; }
    }
}
