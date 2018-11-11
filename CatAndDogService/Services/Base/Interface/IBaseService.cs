using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatAndDogService.Services
{
    public interface IBaseService<T>
    {

        Task<IList<T>> GetRandomListAnimal(int limit);
       
    }
}
