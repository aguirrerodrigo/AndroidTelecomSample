using Android.App;
using Android.Content;
using Android.Telecom;
using Android.Telephony;
using AndroidTelecomSample.Interactors;

namespace AndroidTelecomSample.Droid.Interactors
{
    public class PhoneInteractor : PhoneStateListener, IPhoneInteractor
    {
        private readonly TelecomManager telecom;

        public PhoneInteractor()
        {
            this.telecom = (TelecomManager)Application.Context.GetSystemService(Context.TelecomService);
        }

        public void Call(string phoneNumber)
        {
            var intent = new Intent(Application.Context, typeof(CallActivity));
            intent.PutExtra(nameof(phoneNumber), phoneNumber);
            intent.AddFlags(ActivityFlags.SingleTop | ActivityFlags.NewTask);

            Application.Context.StartActivity(intent);
        }

        public void Hangup()
        {
            this.telecom.EndCall();
        }
    }
}
