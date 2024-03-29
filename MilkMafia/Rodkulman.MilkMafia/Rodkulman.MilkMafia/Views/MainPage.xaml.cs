﻿using System;
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
        private readonly NavigationPage categoryPage;

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            categoryPage = (NavigationPage)Detail;
        }

        protected override bool OnBackButtonPressed()
        {
            if (Detail != categoryPage)
            {
                Detail = categoryPage;

                IsPresented = false;

                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        public async Task NavigateFromMenu(Category category)
        {
            if (!MenuPages.ContainsKey(category))
            {
                var page = new NavigationPage(new ProductListView(category));

                MenuPages.Add(category, page);
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