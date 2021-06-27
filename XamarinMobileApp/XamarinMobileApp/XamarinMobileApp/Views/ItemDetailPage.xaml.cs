using System.ComponentModel;
using Xamarin.Forms;
using XamarinMobileApp.ViewModels;

namespace XamarinMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}