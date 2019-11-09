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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ServerDataStore.GetCategoriesAsync().ContinueWith(x =>
            {
                (Application.Current as App).SetCategories(x.Result);

                ServerDataStore.GetProductsAsync().ContinueWith(y =>
                {
                    (Application.Current as App).SetProducts(y.Result);

                    Application.Current.MainPage = new MainPage();
                });
            });                        
        }
    }
}