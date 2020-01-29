using Xamarin.Forms;
using CostRegisterMobile.Views;
using CostRegisterMobile.Services;
using CostRegister.Services;
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

            DependencyService.Register<IDialogService, DialogService>();
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
