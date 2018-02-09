using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIClient.Data
{
    interface IRestServices<T>
    {
        Task<List<T>> RefreshDataAsync();
        Task SaveItemAsync(T obj, bool isNewItem);
        Task DeleteItemAsync(string id);
    }
}
