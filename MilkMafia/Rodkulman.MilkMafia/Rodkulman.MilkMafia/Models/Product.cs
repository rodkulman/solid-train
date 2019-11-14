using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodkulman.MilkMafia.Models
{
    public class Product : BaseImageModel
    {
        private string imageId;

        #region TableMapping
        public int Id { get; set; }
        public string MaterialId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ExpirationDays { get; set; }
        public double UnitPrice { get; set; }
        public double STTax { get; set; }
        public double STPrice { get; set; }
        public override string ImageId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(imageId))
                {
                    return string.IsNullOrWhiteSpace(MaterialId) ? "placeholder" : MaterialId;
                }
                else
                {
                    return imageId;
                }

            }
            set { imageId = value; }
        }

        #endregion

        #region Relations
        public Category Category { get; set; }
        public ProductQuantity Quantity { get; set; }
        public Paletization Paletization { get; set; }
        #endregion
    }
}
