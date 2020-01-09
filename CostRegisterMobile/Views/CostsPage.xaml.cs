using CostRegisterMobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostsPage : CustomContentPage
    {
        public CostsPage()
        {
            InitializeComponent();

            BindingContext = new CostsViewModel();
        }
    }
}