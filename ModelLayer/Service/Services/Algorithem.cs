using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Algorithem : IAlgorithem
    {
        public Task<string> getBasket()
        {
            
         return getData();
           
        }

        public async Task<string> getData()
        {
            
            string url = "https://jsonplaceholder.typicode.com/posts";
            using (HttpClient client = new HttpClient())
            {
                //token
              //  client.DefaultRequestHeaders.Add("Authorization", "Bearer ");
                HttpResponseMessage response = await client.GetAsync(url);
                try
                {
                    response.EnsureSuccessStatusCode(); //200
                    string responseBody =await  response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                catch (Exception ex)
                {
                    
                    return "not success...";
                }
            }
        }
        
    }
}
