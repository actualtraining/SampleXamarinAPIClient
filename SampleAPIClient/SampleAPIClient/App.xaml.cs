
using SampleAPIClient.Data;
using SampleAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OneSignal;

using Xamarin.Forms;

namespace SampleAPIClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CourseList());

            OneSignal.Current.StartInit("d95679b6-962d-4690-bd32-80b14fa68f1e")
                 .EndInit();
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
