using CostRegisterMobile.Enums;
using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace CostRegisterMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private MainPage RootPage => Application.Current.MainPage as MainPage;

        private List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();
            FillMenuItems();

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }

        private void FillMenuItems()
        {
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemTypeEnum.Costs, Title="Új költség rögzítése" },
                new HomeMenuItem {Id = MenuItemTypeEnum.Income, Title="Bevétel rögzítése" },
                new HomeMenuItem {Id = MenuItemTypeEnum.PlanCost, Title="Költség-előretervezés" },
                new HomeMenuItem {Id = MenuItemTypeEnum.CostStatistics, Title="Kiadási statisztikák" },
                new HomeMenuItem {Id = MenuItemTypeEnum.IncomeStatistics, Title="Bevételi statisztikák" },
                new HomeMenuItem {Id = MenuItemTypeEnum.PlanStatistics, Title="Előretervezési statisztikák" },
                new HomeMenuItem {Id = MenuItemTypeEnum.CostPerCategoryStatistics, Title="Kiadási statisztikák/kategória" },
                new HomeMenuItem {Id = MenuItemTypeEnum.Settings, Title="Beállítások" }
            };
        }
    }
}