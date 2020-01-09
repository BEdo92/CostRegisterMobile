using CostRegisterMobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace CostRegisterMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostPerCategoryStatisticsPage : CustomContentPage
    {
        public CostPerCategoryStatisticsPage()
        {
            InitializeComponent();

            BindingContext = new CostPerCategoryStatisticsViewModel();
        }
    }
}