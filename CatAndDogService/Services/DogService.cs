using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatAndDogService.Conts;
using CatAndDogService.Model;
using CatAndDogService.Services.Interface;
using Newtonsoft.Json;

namespace CatAndDogService.Services
{
   
    public class DogService : BaseService, IDogService
        {
            #region Constructor
            public DogService() : base(UrlConst.DogUrl)
            {

            }
            #endregion

            #region Method


            /// <summary>
            /// Gets the random list animal.
            /// </summary>
            /// <returns>The random list animal.</returns>
            /// <param name="limit">Limit.</param>
            public async Task<IList<DogModel>> GetRandomListAnimal(int limit =50 )
            {
                var result = await Client.GetAsync(string.Format("search?size=med&mime_types=jpg&format=json&has_breeds=true&order=RANDOM&limit={0}", limit));
                if (result.IsSuccessStatusCode)
                    return null;

                var content = await result.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<List<DogModel>>(content));
            }
            #endregion
        }

}
