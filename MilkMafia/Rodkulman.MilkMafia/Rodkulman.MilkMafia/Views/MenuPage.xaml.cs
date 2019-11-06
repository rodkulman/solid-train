using Rodkulman.MilkMafia.Models;
using Rodkulman.MilkMafia.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rodkulman.MilkMafia.Views
{
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        
        public MenuPage()
        {
            InitializeComponent();

            MenuItens.ItemsSource = (Application.Current as App).Categories;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var category = e.SelectedItem as Category;

            await RootPage.NavigateFromMenu(category);
        }
    }
}