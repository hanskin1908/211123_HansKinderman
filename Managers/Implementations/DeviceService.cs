using _211123_HansKinderman.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace _211123_HansKinderman.Managers.Implementations
{

    public class DeviceService:IDeviceServices
    {

        private readonly IConfiguration _config;
        HttpClient client = new HttpClient();

        public DeviceService(IConfiguration configuration)
        {
            _config = configuration;
        }


        public async Task<Response<Device>> GetDetails(Device dispositivo)
        {
            var response = new Response<Device>();
            try
            {
                client.BaseAddress = new Uri("https://fleetsapapiqa.azurewebsites.net");
                Device dev = new Device()
                {
                    CompanyId = dispositivo.CompanyId,
                    Imei = dispositivo.Imei,
                   
                };
                var queryString = new StringContent(JsonConvert.SerializeObject(dev), Encoding.UTF8, "application/json");
                var res = await client.PostAsync("api/GetIMEIDataServicesByIMEIAndCompany", queryString);
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.UnitResp = JsonConvert.DeserializeObject<Device>(results);
                }
                else
                {
                    response.Error = true;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
            }
            return response;


        }

    }
}
