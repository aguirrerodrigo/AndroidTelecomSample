using Android.App;
using Android.OS;

namespace AndroidTelecomSample.Droid
{
    [Activity(Label = "OnCallActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class OnCallActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnStart()
        {
            base.OnStart();
            this.Finish();
        }
    }
}