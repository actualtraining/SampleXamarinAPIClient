using SampleAPIClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleAPIClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseList : ContentPage
    {
        public CourseList()
        {
            InitializeComponent();
        }

        private void ListCourse_Refreshing(object sender, EventArgs e)
        {
            OnAppearing();
            listCourse.IsRefreshing = false;
        }

        protected async override void OnAppearing()
        {
            CourseServices myService = new CourseServices();
            listCourse.ItemsSource = await myService.RefreshDataAsync();
        }
    }
}