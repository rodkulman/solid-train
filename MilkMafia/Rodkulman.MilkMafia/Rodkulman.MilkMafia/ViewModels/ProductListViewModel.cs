using MvvmHelpers;
using Rodkulman.MilkMafia.Models;
using Rodkulman.MilkMafia.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        }

        public async Task LoadProducts()
        {
            this.IsBusy = true;

            var products = await ServerDataStore.GetProductsAsync(category);
            this.Products = new ObservableRangeCollection<Product>(products);

            this.IsBusy = false;
        }
    }
}
