using Rodkulman.MilkMafia.Models;
using Rodkulman.MilkMafia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rodkulman.MilkMafia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductView : ContentPage
    {
        public ProductView(Product product)
        {
            InitializeComponent();

            this.BindingContext = new ProductViewModel(product);
        }
    }
}