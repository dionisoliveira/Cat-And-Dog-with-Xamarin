using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatAndDogService.Services
{
    public abstract class BaseService
    {

        public HttpClient Client = new HttpClient();

        public BaseService(string baseUrl)
        {
            Client.BaseAddress = new Uri(baseUrl);
          
        }

      
    }
}
