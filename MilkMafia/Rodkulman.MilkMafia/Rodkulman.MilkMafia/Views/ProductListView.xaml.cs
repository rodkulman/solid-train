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
    public partial class ProductListView : ContentPage
    {
        private ProductListViewModel viewModel;

        public ProductListView(Category category)
        {
            InitializeComponent();

            this.BindingContext = viewModel = new ProductListViewModel(category);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}