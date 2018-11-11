using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatAndDogService.Services.Interface
{
    public interface IAnimalService
    {
        Task<IList<object>> GetRandomListAnimal(int limit = 0);
    }
}
