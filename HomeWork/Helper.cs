using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                string responseContent = await response.Content.ReadAsStringAsync();

                var deptList = JsonSerializer.Deserialize<List<User>>(responseContent);
                var newlist = deptList.FindAll(predicate);
                return newlist;
            }
            else return null;
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
