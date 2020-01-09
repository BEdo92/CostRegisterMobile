using CostRegisterMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostStatisticsPage : CustomContentPage
    {
        public CostStatisticsPage()
        {
            InitializeComponent();

            BindingContext = new CostStatisticsViewModel();
        }
    }
}