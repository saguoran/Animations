using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI0MzU2QDMxMzcyZTMyMmUzMFhRaXVjU0VPVXoxbHBpTU90TGlmUjdNYzVYVWlnMTN3cFJsalQ1dFBMOEE9");
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
