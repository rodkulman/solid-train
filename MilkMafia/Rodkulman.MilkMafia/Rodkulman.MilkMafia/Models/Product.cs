using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodkulman.MilkMafia.Models
{
    public class Product : BaseImageModel
    {
        public Category Category { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ImageId { get; set; }
    }
}
