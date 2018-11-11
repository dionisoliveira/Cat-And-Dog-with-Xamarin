using System;
using CatAndDogService.Services;
using Xunit;

namespace CatAndDogTest
{
    public class CatTest
    {

        public CatService catService = new CatService();
        [Fact]
        public async void Test1()
        {
            var result =await catService.GetRandomListAnimal(25);

            Assert.Equal(25, result.Count);
        }
    }
}
