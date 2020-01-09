using System;
using System.Threading.Tasks;

namespace CostRegisterMobile.Helpers
{
    public interface IMessageBoxService
    {
        Task<bool> ShowConfirmation(string message,
            string title = "Figyelmeztetés!",
            string buttonConfirmText = "OK",
            string buttonCancelText = "Mégse");

        Task ShowMessage(string message, string title);
    }
}
