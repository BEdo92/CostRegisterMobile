using CostRegisterMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : CustomContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = new SettingsViewModel();
        }
    }
}