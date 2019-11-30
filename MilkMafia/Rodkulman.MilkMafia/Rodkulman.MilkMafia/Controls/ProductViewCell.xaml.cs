using Rodkulman.MilkMafia.Models;
using Rodkulman.MilkMafia.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rodkulman.MilkMafia.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductViewCell : ViewCell
    {
        public ProductViewCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(Quantity));
        }

        protected override async void OnTapped()
        {
            base.OnTapped();

            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ProductView(this.BindingContext as Product)));
        }

        public double Price
        {
            get
            {
                if (!(this.BindingContext is Product product))
                {
                    return 0;
                }
                else if (product.Quantity?.Any() ?? false)
                {
                    return product.Quantity.OrderByDescending(x => x.Quantity).First().Price * (product.STTax != -1 ? 1 + product.STTax : 1);
                }
                else
                {
                    return product.UnitPrice * (product.STTax != -1 ? 1 + product.STTax : 1);
                }
            }
        }

        public int Quantity
        {
            get
            {
                if (!(this.BindingContext is Product product) || !(product.Quantity?.Any() ?? false))
                {
                    return 1;
                }
                else
                {
                    return product.Quantity.OrderByDescending(x => x.Quantity).First().Quantity;
                }
            }
        }
    }
}