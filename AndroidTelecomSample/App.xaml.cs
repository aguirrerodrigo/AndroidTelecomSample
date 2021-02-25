using System;
using AndroidTelecomSample.Services;
using AndroidTelecomSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidTelecomSample
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.RegisterViewModels();

            MainPage = new MainPage();
        }

        private void RegisterViewModels()
        {
            if (ServiceLocator.Instance.IsLocked)
                return;

            ServiceLocator.Instance.Register<MainPageViewModel>(ServiceLifetime.Transient);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
