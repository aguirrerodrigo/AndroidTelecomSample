using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Telecom;

namespace AndroidTelecomSample.Droid
{
    [Activity(Label = "CallActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class CallActivity : Activity
    {
        private readonly TelecomManager telecom;

        public CallActivity()
        {
            this.telecom = (TelecomManager)Application.Context.GetSystemService(Context.TelecomService);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CallActivity);
        }

        protected override void OnStart()
        {
            base.OnStart();

            var phoneNumber = string.Empty;
            phoneNumber = this.Intent.GetStringExtra(nameof(phoneNumber));

            var options = new Bundle();
            options.PutBoolean(TelecomManager.ExtraStartCallWithSpeakerphone, true);
            this.telecom.PlaceCall(Android.Net.Uri.FromParts("tel", phoneNumber, null), options);

            Task.Run(async () =>
            {
                await Task.Delay(500);

                var intent = new Intent(MainActivity.Instance, typeof(OnCallActivity));
                intent.AddFlags(ActivityFlags.SingleTop | ActivityFlags.NewTask);

                Application.Context.StartActivity(intent);
            });
            
            this.Finish();
        }
    }
}