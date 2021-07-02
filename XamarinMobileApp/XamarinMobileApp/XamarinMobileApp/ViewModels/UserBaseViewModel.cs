using System;
using System.Collections.Generic;
using System.Text;
using XamarinMobileApp.Models;

namespace XamarinMobileApp.ViewModels
{
    public class UserBaseViewModel : BaseViewModel
    {
        protected string name;
        protected string lastname;
        protected string cpf;
        protected DateTime birthday;
        protected Gender gender;

        protected DateTime minimumDate = new DateTime(1900, 1, 1);
        protected DateTime maximumDate = DateTime.Today;

        protected string street;
        protected string number;
        protected string district;
        protected string city;
        protected string state;
        protected string addressComplement;
        protected string cep;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
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
            get
            {
                return Enum.GetName(typeof(Gender), gender);
            }

            set
            {
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
    }
}
