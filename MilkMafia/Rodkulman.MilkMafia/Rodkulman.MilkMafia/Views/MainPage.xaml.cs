using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rodkulman.MilkMafia.Models;

namespace Rodkulman.MilkMafia.Views
{    
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        private readonly Dictionary<Category, NavigationPage> MenuPages = new Dictionary<Category, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(Category.All, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(Category category)
        {
            if (!MenuPages.ContainsKey(category))
            {
                MenuPages.Add(category, new NavigationPage());
            }

            var newPage = MenuPages[category];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android) { await Task.Delay(100); }

                IsPresented = false;
            }
        }
    }
}