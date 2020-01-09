using System.Linq;
using CostRegisterMobile.EntityModels;

namespace CostRegisterMobile.Repositories
{
    public class SettingsRepository : CostPlansRepositoryBase<Settings>
    {
        public SettingsRepository(CostPlansContext costPlansContext) : base(costPlansContext)
        {
        }

        public void Update(int id, int data)
        {
            var toModify = _context.Settings.First(i => i.ID == id);
            toModify.SettingMode = data;
        }
    }
}
