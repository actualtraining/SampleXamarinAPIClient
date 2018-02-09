
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

        public Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
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

        public Task SaveItemAsync(Course obj, bool isNewItem)
        {
            throw new NotImplementedException();
        }
    }
}
