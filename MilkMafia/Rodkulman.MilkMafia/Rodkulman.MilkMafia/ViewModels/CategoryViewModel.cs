using MvvmHelpers;
using Rodkulman.MilkMafia.Models;
using Rodkulman.MilkMafia.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodkulman.MilkMafia.ViewModels
{
    public class CategoryViewModel : BaseViewModel    
    {        
        public ObservableRangeCollection<Category> Categories { get; } = new ObservableRangeCollection<Category>();

        public async Task LoadCategories()
        {
            this.IsBusy = true;
            var cat = await ServerDataStore.GetCategoriesAsync();
            this.IsBusy = false;

            this.Categories.AddRange(cat);
        }
    }
}
