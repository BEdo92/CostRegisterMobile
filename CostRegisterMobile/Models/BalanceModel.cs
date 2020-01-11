using CostRegisterMobile.Enums;
using CostRegisterMobile.Repositories;
using System;
using System.Linq;
using Xamarin.Forms;

namespace CostRegisterMobile.Models
{
    public class BalanceModel
    {
        private readonly string toGuiForBalance = AppResources.ForStringTextCurrentBalance;

        public IUnitOfWork Repo => DependencyService.Get<IUnitOfWork>();

        public int Balance
        {
            get
            {
                int income = Repo.IncomeRepository.ReadAllIncomeMoney().Sum();
                int costs = Repo.CostsRepository.ReadAllCostMoney().Sum();
                int plans = InvolvePlans ? Plans : 0;
                return income - costs - plans;
            }
        }

        public string BalanceString
        {
            get
            {
                string infoForInvolvingplans = InvolvePlans ? AppResources.ForStringHasPlans : AppResources.ForStringNotInvolvePlans;
                string infoForHasPlans = HasPlans ? infoForInvolvingplans : AppResources.ForStringNoPlans;
                return $"{toGuiForBalance} {Environment.NewLine} {Balance.ToString("# ##0")} {AppResources.Currency} {infoForHasPlans}";
            }
        }

        public int Plans => Repo.PlansRepository.ReadCostPlansMoney().Sum();

        public bool HasPlans => Plans > 0;

        public bool InvolvePlans
        {
            get
            {
                var settingsObject = Repo.SettingsRepository.GetById(1);
                return settingsObject.SettingMode == (int)BalanceSettingsModeEnum.WithPlans;
            }
        }
    }
}