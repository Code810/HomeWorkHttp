using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Helper
    {
        public async Task<List<User>> GetHttpData(Predicate<User> predicate)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "https://jsonplaceholder.typicode.com/posts";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
           

            if (response.IsSuccessStatusCode)
            {
                var userList = await response.Content.ReadFromJsonAsync<List<User>>();

                var filteredList = userList.FindAll(predicate);
                return filteredList;
            }
             return null;
        }
            
        public  void AddDataFile(List<User> data)
        {
           
                string strserialize = JsonSerializer.Serialize(data);
            string fileName = "Data.txt";
                string filepath = "C:\\Users\\seidb\\OneDrive\\Masaüstü\\Projects";
                string fullFilePath = Path.Combine(filepath, fileName);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            File.WriteAllText(fullFilePath, strserialize);
                Console.WriteLine("Adding text to file successful");
          
          
        }

   
    }
}
