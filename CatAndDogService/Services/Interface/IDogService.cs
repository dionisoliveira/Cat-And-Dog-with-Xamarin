using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatAndDogService.Model;
namespace CatAndDogService.Services.Interface
{
    public interface IDogService
    {
        Task<IList<DogModel>> GetRandomListAnimal(int limit);
    }
}
