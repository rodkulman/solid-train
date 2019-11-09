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
    public class Category : BaseImageModel
    {
        public static Category All { get; } = new Category() { Name = "All", ImageId = "placeholder" };        

        public int Id { get; set; }
        public string Name { get; set; }
        public override string ImageId { get; set; }
    }
}
