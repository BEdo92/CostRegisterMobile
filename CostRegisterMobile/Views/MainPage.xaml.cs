using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using CostRegisterMobile.Enums;

namespace CostRegisterMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(0, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemTypeEnum.Costs:
                        MenuPages.Add(id, new NavigationPage(new CostsPage()));
                        break;
                    case (int)MenuItemTypeEnum.Income:
                        MenuPages.Add(id, new NavigationPage(new IncomePage()));
                        break;
                    case (int)MenuItemTypeEnum.PlanCost:
                        MenuPages.Add(id, new NavigationPage(new PlanCostsPage()));
                        break;
                    case (int)MenuItemTypeEnum.CostStatistics:
                        MenuPages.Add(id, new NavigationPage(new CostStatisticsPage()));
                        break;
                    case (int)MenuItemTypeEnum.IncomeStatistics:
                        MenuPages.Add(id, new NavigationPage(new IncomeStatisticsPage()));
                        break;
                    case (int)MenuItemTypeEnum.PlanStatistics:
                        MenuPages.Add(id, new NavigationPage(new PlanStatisticsPage()));
                        break;
                    case (int)MenuItemTypeEnum.CostPerCategoryStatistics:
                        MenuPages.Add(id, new NavigationPage(new CostPerCategoryStatisticsPage()));
                        break;
                    case (int)MenuItemTypeEnum.Settings:
                        MenuPages.Add(id, new NavigationPage(new SettingsPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}