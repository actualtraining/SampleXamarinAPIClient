
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleAPIClient.Models;

namespace SampleAPIClient.Data
{
    public class CourseServices : IRestServices<Course>
    {
        private HttpClient client;
        public List<Course> CourseItems { get; set; }

        public CourseServices()
        {
            client = new HttpClient();
        }

        public async Task DeleteItemAsync(string id)
        {
            var url = new Uri(String.Format("{0}/{1}", Constans.RestUrl + "api/Courses", id));
            try
            {
                var response = await client.DeleteAsync(url);
                if (!response.IsSuccessStatusCode)
                    Debug.WriteLine("Data gagal didelete");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Kesalahan:" + ex.Message);
            }
        }

        public async Task<List<Course>> RefreshDataAsync()
        {
            CourseItems = new List<Course>();
            var uri = new Uri(Constans.RestUrl + "api/Courses");
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    CourseItems = JsonConvert.DeserializeObject<List<Course>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Kesalahan: " + ex.Message);
            }
            return CourseItems;
        }

        public async Task SaveItemAsync(Course obj, bool isNewItem)
        {
            var urlPost = new Uri(Constans.RestUrl + "api/Courses");
            var urlPut = new Uri(String.Format("{0}/{1}", 
                Constans.RestUrl + "api/Courses", obj.CourseID));

            try
            {
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(urlPost, content);
                }
                else
                {
                    response = await client.PutAsync(urlPut, content);
                }

                if (!response.IsSuccessStatusCode)
                    Debug.WriteLine("Data tidak berhasil disimpan");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Kesalahan: " + ex.Message);
            }
        }
    }
}
