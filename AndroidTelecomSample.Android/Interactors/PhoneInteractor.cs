using Android.Content;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Telecom;
using AndroidTelecomSample.Interactors;

namespace AndroidTelecomSample.Droid.Interactors
{
    public class PhoneInteractor : IPhoneInteractor
    {
        private readonly TelecomManager telecom;

        public PhoneInteractor()
        {
            this.telecom = (TelecomManager)Android.App.Application.Context.GetSystemService(Context.TelecomService);
        }

        public void Call(string phoneNumber)
        {
            var options = new Bundle();
            options.PutBoolean(TelecomManager.ExtraStartCallWithSpeakerphone, true);
            this.telecom.PlaceCall(Uri.Parse(phoneNumber), options);
        }

        public void Hangup()
        {
            this.telecom.EndCall();
        }
    }
}
