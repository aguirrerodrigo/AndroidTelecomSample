namespace AndroidTelecomSample.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new AndroidTelecomSample.App());
        }
    }
}
