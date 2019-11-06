using Rodkulman.MilkMafia.Services;
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
    public partial class SplashView : ContentPage
    {
        public SplashView()
        {
            InitializeComponent();            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var categories = await ServerDataStore.GetCategoriesAsync();

            (Application.Current as App).SetCategories(categories);

            Application.Current.MainPage = new MainPage();
        }
    }
}