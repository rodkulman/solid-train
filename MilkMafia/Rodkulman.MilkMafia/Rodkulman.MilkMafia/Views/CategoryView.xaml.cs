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

            CategoryItens.FlowItemsSource = (Application.Current as App).Categories;
        }

        private async void CategoryItens_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var category = e.Item as Category;

            await RootPage.NavigateFromMenu(category);
        }

        private async void SearchItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SearchView()));
        }
    }
}