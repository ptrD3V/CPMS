using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CPMS.GUI.Models;
using Newtonsoft.Json;

namespace CPMS.GUI.Factories
{
    public class CustomerFactory : BaseFactory<CustomerModel>, ICustomerFactory
    {
        public async Task<IEnumerable<CustomerListModel>> GetCustomerList()
        {
            IEnumerable<CustomerListModel> list;
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var response = await client.GetAsync($"/api/customer/");
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    var result = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<IEnumerable<CustomerListModel>>(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return list;
            }
        }
    }
}
