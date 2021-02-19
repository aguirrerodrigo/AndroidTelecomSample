using System.Windows.Input;
using AndroidTelecomSample.Interactors;
using Xamarin.Forms;

namespace AndroidTelecomSample.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IPhoneInteractor phone;

        public ICommand CallCommand { get; private set; }
        public ICommand HangupCommand { get; private set; }

        public MainPageViewModel(IPhoneInteractor phone)
        {
            this.phone = phone;

            this.CallCommand = new Command(Call);
            this.HangupCommand = new Command(Hangup);
        }

        private void Hangup(object obj)
        {
            this.phone.Hangup();
        }

        private void Call()
        {
            this.phone.Call("+31600000000");
        }
    }
}
