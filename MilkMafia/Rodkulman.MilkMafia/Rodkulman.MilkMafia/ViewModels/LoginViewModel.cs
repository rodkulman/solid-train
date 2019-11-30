using MvvmHelpers;
using Rodkulman.MilkMafia.Services;
using Rodkulman.MilkMafia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rodkulman.MilkMafia.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string cpf;
        private bool invalidLogin;
        private Command loginCommand;

        public bool InvalidLogin
        {
            get { return invalidLogin; }
            set { SetProperty(ref invalidLogin, value); }
        }

        public string CPF
        {
            get { return cpf; }
            set
            {
                SetProperty(ref cpf, value);
                loginCommand?.ChangeCanExecute();
            }
        }

        public Command LoginCommand => loginCommand ?? (loginCommand = new Command(Login, ValidateCPF));

        private bool ValidateCPF()
        {
            return !string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11;
        }

        private async void Login()
        {
            this.IsBusy = true;

            if (await ServerDataStore.Login(cpf))
            {
                await ServerDataStore.GetDatabase().ContinueWith(x =>
                {
                    (Application.Current as App).SetCategories(x.Result);
                });

                Application.Current.MainPage = new MainPage();
            }
            else
            {
                this.InvalidLogin = true;
            }

            this.IsBusy = false;
        }
    }
}
