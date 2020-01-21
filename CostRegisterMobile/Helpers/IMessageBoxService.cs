using System;
using System.Threading.Tasks;

namespace CostRegisterMobile.Helpers
{
    public interface IMessageBoxService
    {
        Task<bool> ShowConfirmation(string message, string title, string buttonCancelText, string buttonConfirmText = "OK");
        Task ShowMessage(string message, string title);
    }
}
