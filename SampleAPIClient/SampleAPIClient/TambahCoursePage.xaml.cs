using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleAPIClient.Data;
using SampleAPIClient.Models;

namespace SampleAPIClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TambahCoursePage : ContentPage
    {
        private CourseServices courseService;
        public TambahCoursePage()
        {
            InitializeComponent();
            courseService = new CourseServices();
            btnAdd.Clicked += BtnAdd_Clicked;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            var newCourse = new Course
            {
                CourseID = Convert.ToInt32(txtCourseID.Text),
                Title = txtTitle.Text,
                Credits = Convert.ToInt32(txtCredits.Text)
            };
            await courseService.SaveItemAsync(newCourse,true);
            await DisplayAlert("Konfirmasi", "Data " + txtTitle.Text + " berhasil ditambah", "OK");
            await Navigation.PopAsync();
        }
    }
}