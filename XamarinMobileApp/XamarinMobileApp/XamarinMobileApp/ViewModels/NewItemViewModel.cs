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
        private string name;
        private string lastname;
        private string cpf;
        private DateTime birthday;
        private Gender gender;

        private Color? textColor;

        private DateTime minimumDate = new DateTime(1900, 1, 1);
        private DateTime maximumDate = DateTime.Today;

        private string street;
        private string number;
        private string district;
        private string city;
        private string state;
        private string addressComplement;
        private string cep;


        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            if (Name?.Length > 4)
                TextColor = Color.Green;
            else
                TextColor = Color.Red;

            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(lastname);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public Color? TextColor
        {
            get => textColor;
            set => SetProperty(ref textColor, value);
        }

        public string LastName
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }

        public string CPF
        {
            get => cpf;
            set => SetProperty(ref cpf, value);
        }

        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }

        public string Gender
        {
            get {
                switch (gender)
                {
                    case Models.Gender.Unanswered:
                        return "Unanswered";

                    case Models.Gender.Female:
                        return "Female";

                    case Models.Gender.Male:
                        return "Male";

                    case Models.Gender.Other:
                        return "Other";

                    default:
                        return "Unanswered";
                }
            }

            set {
                switch (value)
                {
                    case "Unanswered":
                        gender = Models.Gender.Unanswered;
                        break;

                    case "Female":
                        gender = Models.Gender.Female;
                        break;

                    case "Male":
                        gender = Models.Gender.Male;
                        break;

                    case "Other":
                        gender = Models.Gender.Other;
                        break;

                    default:
                        gender = Models.Gender.Unanswered;
                        break;
                }
            }
        }

        public DateTime MinimumDate
        {
            get => minimumDate;
            set => SetProperty(ref minimumDate, value);
        }

        public DateTime MaximumDate
        {
            get => maximumDate;
            set => SetProperty(ref maximumDate, value);
        }

        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }

        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }

        public string District
        {
            get => district;
            set => SetProperty(ref district, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string State
        {
            get => state;
            set => SetProperty(ref state, value);
        }

        public string AddressComplement
        {
            get => addressComplement;
            set => SetProperty(ref addressComplement, value);
        }

        public string CEP
        {
            get => cep;
            set => SetProperty(ref cep, value);
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
