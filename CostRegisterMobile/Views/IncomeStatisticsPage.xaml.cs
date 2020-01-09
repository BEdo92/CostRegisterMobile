using CostRegisterMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomeStatisticsPage : CustomContentPage
    {
        public IncomeStatisticsPage()
        {
            InitializeComponent();

            BindingContext = new IncomeStatisticsViewModel();
        }
    }
}