using CostRegisterMobile.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CostRegister.Services
{
    public class DialogService : IDialogService
    {
        public async Task<bool> ShowConfirmation(
            string message,
            string title, 
            string buttonCancelText,
            string buttonConfirmText = "OK"
         )
        {
            var result = await Application.Current.MainPage.DisplayAlert(
                    title,
                    message,
                    buttonConfirmText,
                    buttonCancelText);

            return result;
        }

        public async Task ShowMessage(string message, string title)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "OK");
        }

    }
}

