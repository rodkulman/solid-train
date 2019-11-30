using MvvmHelpers;
using Rodkulman.MilkMafia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rodkulman.MilkMafia.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public int Quantity
        {
            get
            {
                if (!(product.Quantity?.Any() ?? false))
                {
                    return 1;
                }
                else
                {
                    return product.Quantity.OrderByDescending(x => x.Quantity).First().Quantity;
                }
            }
        }

        public double QuantityPrice
        {
            get
            {
                if (!(product.Quantity?.Any() ?? false))
                {
                    return product.UnitPrice;
                }
                else
                {
                    return product.Quantity.OrderByDescending(x => x.Quantity).First().Price;
                }
            }
        }

        public double TaxPrice => QuantityPrice * (product.STTax == -1 ? 1 : 1 + product.STTax);
        public int LayerQuantity => product.Paletization.BoxQuantity * product.Paletization.BoxLayerQuantity;
        public int PalletQuantity => product.Paletization.BoxQuantity * product.Paletization.BoxLayerQuantity * product.Paletization.LayerPalletQuantity;

        public ProductViewModel(Product product)
        {
            this.product = product;
        }
    }
}
