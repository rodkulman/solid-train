using MvvmHelpers;
using Rodkulman.MilkMafia.Models;
using Rodkulman.MilkMafia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rodkulman.MilkMafia.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        private Category category;
        private ObservableRangeCollection<Product> products;

        public ObservableRangeCollection<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        public Category Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        public ProductListViewModel(Category category)
        {
            this.Category = category;
            this.Title = category.Name;
        }

        public async Task LoadProducts()
        {
            this.IsBusy = true;

            if (category != Category.All)
            {
                var products = await Task.Run(() => (Application.Current as App).Products.Where(x => x.Category == category));
                this.Products = new ObservableRangeCollection<Product>(products);
            }
            else
            {
                this.Products = (Application.Current as App).Products;
            }

            this.IsBusy = false;
        }
    }
}
