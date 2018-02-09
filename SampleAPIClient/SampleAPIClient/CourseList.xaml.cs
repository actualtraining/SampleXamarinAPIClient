using SampleAPIClient.Data;
using SampleAPIClient.Models;
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
            listCourse.ItemTapped += ListCourse_ItemTapped;
            menuAdd.Clicked += MenuAdd_Clicked;
        }

        private async void MenuAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahCoursePage());
        }

        private async void ListCourse_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Course)e.Item;
            var formDetail = new EditCoursePage();
            formDetail.BindingContext = data;
            await Navigation.PushAsync(formDetail);
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