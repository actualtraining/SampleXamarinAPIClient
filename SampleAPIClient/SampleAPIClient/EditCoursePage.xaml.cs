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
    public partial class EditCoursePage : ContentPage
    {
        private CourseServices courseService;
        public EditCoursePage()
        {
            InitializeComponent();
            courseService = new CourseServices();
            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var jawab = await DisplayAlert("Konfirmasi", "Apakah anda yakin untuk mendelete data?", "Yes", "No");
            if (jawab)
            {
                await courseService.DeleteItemAsync(txtCourseID.Text);
                await Navigation.PopAsync();
            }
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            var currCourse = new Course
            {
                CourseID = Convert.ToInt32(txtCourseID.Text),
                Title = txtTitle.Text,
                Credits = Convert.ToInt32(txtCredits.Text)
            };
            await courseService.SaveItemAsync(currCourse, false);
            await Navigation.PopAsync();
        }
    }
}