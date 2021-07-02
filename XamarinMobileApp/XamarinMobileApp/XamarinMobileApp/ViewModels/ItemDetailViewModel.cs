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
        public UserService userSerivice = new UserService();
        private string itemId;

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

                var user = userSerivice.GetById(int.Parse(UserId));

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
    }
}
