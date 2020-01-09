using CostRegisterMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanCostsPage : CustomContentPage
    {
        public PlanCostsPage()
        {
            InitializeComponent();

            BindingContext = new PlanCostsViewModel();
        }
    }
}