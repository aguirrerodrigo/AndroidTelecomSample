using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidTelecomSample.Droid.Interactors;
using AndroidTelecomSample.Interactors;
using AndroidTelecomSample.Services;

namespace AndroidTelecomSample.Droid
{
    [Activity(Label = "AndroidTelecomSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            this.RegisterServices();
            this.RequestPermissions();

            LoadApplication(new App());
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register<IPhoneInteractor, PhoneInteractor>(ServiceLifetime.Singleton);
        }


        private void RequestPermissions()
        {
            var permissions = new string[]
            {
                Manifest.Permission.CallPhone,
                Manifest.Permission.AnswerPhoneCalls
            };
            this.RequestPermissions(permissions, 0);
        }
    }
}