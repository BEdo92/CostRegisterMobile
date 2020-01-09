using CostRegisterMobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanStatisticsPage : CustomContentPage
    {
        public PlanStatisticsPage()
        {
            InitializeComponent();

            BindingContext = new PlanStatisticsViewModel();
        }
    }
}