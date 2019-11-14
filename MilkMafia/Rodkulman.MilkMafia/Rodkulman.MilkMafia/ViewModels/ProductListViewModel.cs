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

        public Category Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        public ProductListViewModel(Category category)
        {
            this.Category = category;
            this.Title = category.Description;
        }
    }
}
