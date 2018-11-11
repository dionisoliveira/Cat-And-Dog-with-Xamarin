using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatAndDogService.Services.Interface
{
    public interface IAnimalService<T>
    {
         Task<IList<T>> GetRandomListAnimal(int limit);
    }
}
