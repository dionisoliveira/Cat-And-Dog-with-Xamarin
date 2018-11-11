using System.Collections.Generic;
using CatAndDogService.Model;
using CatAndDogService.Conts;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CatAndDogService.Services.Interface;

namespace CatAndDogService.Services
{
    public class CatService : BaseService,ICatService
    {
        #region Constructor
        public CatService() : base(UrlConst.CatUrl)
        {

        }
        #endregion

        #region Method

        /// <summary>
        /// Gets the random list animal.
        /// </summary>
        /// <returns>The random list animal.</returns>
        /// <param name="limit">Limit.</param>
        public async Task<IList<CatModel>> GetRandomListAnimal(int limit=25)
        {
            var result = await Client.GetAsync(string.Format("v1/images/search?size=med&mime_types=jpg&format=json&has_breeds=true&order=RANDOM&limit={0}",limit));
            if (!result.IsSuccessStatusCode)
                return null;

            var content = await result.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<List<CatModel>>(content));
        }
        #endregion
    }
}
