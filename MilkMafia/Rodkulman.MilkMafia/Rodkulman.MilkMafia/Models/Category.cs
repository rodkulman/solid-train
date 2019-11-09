using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MvvmHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rodkulman.MilkMafia.Services;
using Xamarin.Forms;

namespace Rodkulman.MilkMafia.Models
{
    public class Category : BaseImageModel, IEqualityComparer<Category>
    {
        public static Category All { get; } = new Category() { Name = "All", ImageId = "placeholder" };        

        public int Id { get; set; }
        public string Name { get; set; }
        public override string ImageId { get; set; }

        public bool Equals(Category x, Category y)
        {
            if ((x == null) && (y == null))
            {
                return true;
            }
            else if ((x == null) || (y == null))
            {
                return false;
            }
            else if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            else
            {
                return x.Id == y.Id;
            }
        }

        public int GetHashCode(Category obj)
        {
            return obj?.Id.GetHashCode() ?? 0;
        }
    }
}
