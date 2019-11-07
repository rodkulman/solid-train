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
    public class Category : ObservableObject
    {
        public static Category All { get; } = new Category() { Name = "All", ImageId = "placeholder" };

        private byte[] image = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageId { get; set; }

        [JsonIgnore]
        [JsonProperty(Required = Required.Default)]
        public ImageSource Image
        {
            get
            {
                if (image == null && (image = ServerDataStore.GetImage(this)) == null)
                {
                    return null;
                }
                else
                {
                    return ImageSource.FromStream(() => new MemoryStream(image));
                }
            }
        }

        internal void SetImage(byte[] image)
        {
            SetProperty(ref this.image, image, nameof(Image));
        }
    }
}
