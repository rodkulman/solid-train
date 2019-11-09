using MvvmHelpers;
using Newtonsoft.Json;
using Rodkulman.MilkMafia.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Rodkulman.MilkMafia.Models
{
    public abstract class BaseImageModel : ObservableObject
    {
        private byte[] image = null;

        public abstract string ImageId { get; set; }

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
