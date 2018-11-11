using System;
using Xunit;
using CatAndDogService.Services;
using System.Threading.Tasks;

namespace CatAndDogTest
{
    public class DogTest
    {

        public DogService dogService = new DogService();
        [Fact]
        public async void Test1()
        {

            var result = await dogService.GetRandomListAnimal(50);

            Assert.Equal(50, result.Count);
        }
    }
}
