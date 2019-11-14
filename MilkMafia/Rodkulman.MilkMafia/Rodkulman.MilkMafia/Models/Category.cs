using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private string imageId;

        public int Id { get; set; }
        public string Description { get; set; }
        public override string ImageId 
        {
            get
            {
                if (string.IsNullOrWhiteSpace(imageId))
                {
                    return this.Products.FirstOrDefault()?.MaterialId ?? "placeholder";
                }
                else
                {
                    return imageId;
                }
                
            }
            set { imageId = value; }
        }
                
        public ICollection<Product> Products { get; set; }
    }
}
