using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rodkulman.MilkMafia.Services;
using Rodkulman.MilkMafia.Views;
using Rodkulman.MilkMafia.Models;
using System.Collections.Generic;
using MvvmHelpers;

namespace Rodkulman.MilkMafia
{
    public partial class App : Application
    {
        public ObservableRangeCollection<Category> Categories { get; private set; }

        public App()
        {
            InitializeComponent();
                        
            MainPage = new SplashView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void SetCategories(Category[] categories)
        {
            this.Categories = new ObservableRangeCollection<Category>(categories);
        }
    }
}
