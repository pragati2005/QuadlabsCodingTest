using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestProject.Models;

//using Newtonsoft.Json.Linq;
using System.Web.Helpers;

using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using System.IO;
//using System.Web.Script.Serialization;
namespace TestProject.Services
{
    public class LocationService : ILocationService
    {
        private static readonly HttpClient httpClient=new HttpClient();
      
        public async Task<List<LocationModel>> GetLocation()
        {
            try
            {
                HttpResponseMessage response =  httpClient.GetAsync("http://getnearbycities.geobytes.com/GetNearbyCities?callback=?&radius=1000").Result;
                response.EnsureSuccessStatusCode();
               
                string responseBody = await response.Content.ReadAsStringAsync();
                StringBuilder str = new StringBuilder();
                str.Append(responseBody);
                str.Remove(0, 2);
                str.Remove(str.Length - 2, 2);
                List<LocationModel> locmodel = new List<LocationModel>();
                // iterating-over-json-object-in-c-sharp :
                dynamic dynJson = JsonConvert.DeserializeObject(str.ToString());
                foreach (var item in dynJson)
                {

                    locmodel.Add(new LocationModel()
                    {
                        Country = item[3],
                        City = item[1],
                        State = item[12]
                    });
                }
                // List<string[]> listobj = new List<string[]>();

              
                return locmodel;
           

                /*onsole.WriteLine(responseBody);*/
            }
            catch (HttpRequestException e)
            {
                return null;
                //Console.WriteLine("\nException Caught!");
                //Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
