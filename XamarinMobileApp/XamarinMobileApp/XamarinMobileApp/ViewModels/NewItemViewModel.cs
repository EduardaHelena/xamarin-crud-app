using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinMobileApp.Models;
using XamarinMobileApp.Services;

namespace XamarinMobileApp.ViewModels
{
    public class NewItemViewModel : UserBaseViewModel
    {


        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return true;
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var userService = new UserService();

            User user = new User()
            {
                Name = Name,
                LastName = LastName,
                CPF = CPF,
                Birthday = Birthday,
                Gender = gender,
                Address = new Address
                {
                    Street = Street,
                    Number = Number,
                    District = District,
                    City = City,
                    State = State,
                    AddressComplement = AddressComplement,
                    CEP = CEP
                }
            };

            userService.CreateUser(user);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
