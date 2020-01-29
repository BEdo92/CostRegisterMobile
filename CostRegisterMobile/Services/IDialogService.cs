using System.Threading.Tasks;

namespace CostRegisterMobile.Services
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmation(string message, string title, string buttonCancelText, string buttonConfirmText = "OK");

        Task ShowMessage(string message, string title);
    }
}
