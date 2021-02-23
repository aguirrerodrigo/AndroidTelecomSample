using System.Threading.Tasks;
using Android.Content;
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
            this.telecom.PlaceCall(Uri.FromParts("tel", phoneNumber, null), options);

            Task.Run(async () =>
            {
                await Task.Delay(500);

                var intent = new Intent(MainActivity.Instance, typeof(OnCallActivity));
                intent.AddFlags(ActivityFlags.SingleTop | ActivityFlags.NewTask);
                MainActivity.Instance.StartActivity(intent);
            });
            
        }

        public void Hangup()
        {
            this.telecom.EndCall();
        }
    }
}
