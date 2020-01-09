using CostRegisterMobile.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomContentPage : ContentPage
    {
        public CustomContentPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            (BindingContext as BaseViewModel)?.RefreshPage();

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            (BindingContext as BaseViewModel)?.HidePage();

            base.OnDisappearing();
        }
    }
}