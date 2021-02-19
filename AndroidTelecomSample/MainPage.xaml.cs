using AndroidTelecomSample.Services;
using AndroidTelecomSample.ViewModels;
using Xamarin.Forms;

namespace AndroidTelecomSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = ServiceLocator.Instance.GetInstance<MainPageViewModel>();
        }
    }
}
