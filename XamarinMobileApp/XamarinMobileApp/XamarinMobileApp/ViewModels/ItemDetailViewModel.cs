using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMobileApp.Models;
using XamarinMobileApp.Services;

namespace XamarinMobileApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]


    public class ItemDetailViewModel : UserBaseViewModel
    {
        public UserService userService = new UserService();
        private string itemId;

        public Command UpdateCommand { get; }
        public Command DeleteCommand { get; }

        public ItemDetailViewModel()
        {
            UpdateCommand = new Command(OnUpdate);
            DeleteCommand = new Command(OnDelete);
            this.PropertyChanged +=
                (_, __) => UpdateCommand.ChangeCanExecute();
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public void LoadItemId(string UserId)
        {
            try
            {

                var user = userService.GetById(int.Parse(UserId));

                Name = user.Name;
                LastName = user.LastName;
                CPF = user.CPF;
                Birthday = user.Birthday;
                Gender = Enum.GetName(typeof(Gender), user.Gender);

                Street = user.Address.Street;
                Number = user.Address.Number;
                District = user.Address.District;
                City = user.Address.City;
                State = user.Address.State;
                AddressComplement = user.Address.AddressComplement;
                CEP = user.Address.CEP;


            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnUpdate()
        {

            User user = new User()
            {
                Id = int.Parse(itemId),
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

            var result = userService.UpdateUser(user);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {

            userService.DeleteUser(int.Parse(itemId));

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
