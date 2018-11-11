using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatAndDogService.Services
{
    public abstract class BaseService
    {

        public HttpClient ClientRest = new HttpClient();

        public BaseService(string baseUrl)
        {
            ClientRest.BaseAddress = new Uri(baseUrl);
          
        }

      
    }
}
