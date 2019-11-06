using Rodkulman.MilkMafia.Models;
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
    public partial class CategoryView : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public CategoryView()
        {
            InitializeComponent();

            CategoryItens.ItemsSource = (Application.Current as App).Categories;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var category = e.Item as Category;

            await RootPage.NavigateFromMenu(category);
        }
    }
}