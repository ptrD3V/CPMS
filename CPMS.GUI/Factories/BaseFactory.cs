using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.GUI.Factories
{
    public class BaseFactory<T> : IBaseFactory<T> where T : class
    {
        public async Task<IEnumerable<T>> MapToList(HttpClient client, string path)
        {
            var response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            var map = JsonConvert.DeserializeObject<IEnumerable<T>>(result);
            return map;
        }

        public async Task<bool> PostObject(string path, T model)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var response = await client.PostAsync(path, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> PutObject(string path, T model)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var response = await client.PutAsync(path, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return true;
        }

        public async Task<T> GetObject(string path)
        {
            T map;
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var response = await client.GetAsync(path);
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    var result = await response.Content.ReadAsStringAsync();
                    map = JsonConvert.DeserializeObject<T>(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return map;
        }

        public async Task<bool> DeleteObject(string path)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var response = await client.DeleteAsync(path);
                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return true;
        }
    }
}
