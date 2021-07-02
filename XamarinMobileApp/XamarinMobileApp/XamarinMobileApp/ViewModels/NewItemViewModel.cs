using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinMobileApp.Models;
using XamarinMobileApp.Services;

namespace XamarinMobileApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private Color? textColor;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            if (Text?.Length > 4)
                TextColor = Color.Green;
            else
                TextColor = Color.Red;

            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public Color? TextColor
        {
            get => textColor;
            set => SetProperty(ref textColor, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                Name = Text,
                LastName = Description,
                Birthday = DateTime.Today.AddYears(-18),
                CPF = "11111111111",
                Gender = Gender.Male,
                Address = new Address
                {
                    AddressComplement = "4022",
                    CEP = "21625140",
                    City = "Rio",
                    District = "rio",
                    Number = "1",
                    State = "Rio",
                    Street = "Rio"

                }
            };

            userService.CreateUser(user);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
