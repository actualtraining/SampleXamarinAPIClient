using SampleAPIClient.Data;
using SampleAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SampleAPIClient
{
    public partial class App : Application
    {
        private static IRestServices<Course> cService;
        public static IRestServices<Course> CService
        {
            get
            {
                if (cService != null)
                {
                    cService = new CourseServices();
                }
                return cService;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new SampleAPIClient.MainPage();
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
