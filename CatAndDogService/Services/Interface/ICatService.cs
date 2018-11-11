using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatAndDogService.Model;
namespace CatAndDogService.Services.Interface
{
    public interface ICatService
    {
        Task<IList<CatModel>> GetRandomListAnimal(int limit);
       
    }
}
