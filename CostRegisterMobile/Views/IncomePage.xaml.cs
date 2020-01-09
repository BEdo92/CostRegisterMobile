using CostRegisterMobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomePage : CustomContentPage
    {
        public IncomePage()
        {
            InitializeComponent();

            BindingContext = new IncomeViewModel();
        }
    }
}