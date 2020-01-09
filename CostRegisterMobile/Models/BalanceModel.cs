using CostRegisterMobile.Enums;
using CostRegisterMobile.Repositories;
using System;
using System.Linq;
using Xamarin.Forms;

namespace CostRegisterMobile.Models
{
    public class BalanceModel
    {
        private const string toGuiForBalance = "Aktuális egyenleg:";

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
                string infoForInvolvingplans = InvolvePlans ? "(Tervezettel)" : $"(Tervezettel{Environment.NewLine}nem számol)";
                string infoForHasPlans = HasPlans ? infoForInvolvingplans : "(Nincs tervezett)";
                return $"{toGuiForBalance} {Environment.NewLine} {Balance.ToString("# ##0")} Ft {infoForHasPlans}";
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