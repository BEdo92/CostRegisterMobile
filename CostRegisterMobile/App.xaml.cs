using Xamarin.Forms;
using CostRegisterMobile.Views;
using CostRegisterMobile.Helpers;
using CostRegister.Helpers;
using CostRegisterMobile.Repositories;
using CostRegisterMobile.EntityModels;
using CostRegisterMobile.Models;

namespace CostRegisterMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IMessageBoxService, MessageBoxService>();
            DependencyService.Register<IUnitOfWork, UnitOfWork>();
            DependencyService.Register<CostPlansContext>();
            DependencyService.Register<BalanceModel>();

            using var dbContext = new CostPlansContext();
            dbContext.Database.EnsureCreated();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
