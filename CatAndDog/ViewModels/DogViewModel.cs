using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using CatAndDogService.Services.Interface;
using System.Linq;
using CatAndDog.ViewModels;
using CatAndDogService.Model;
using System.Collections.Generic;

namespace CatAndDog
{
    public class DogViewModel : AnimalBaseViewModel
    {
        #region Fields
        private IDogService _service => DependencyService.Get<IDogService>();
        #endregion

        #region Command
        public Command LoadItemsCommand { get; set; }
        #endregion

        #region Constructor
        public DogViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Animal>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


        }


        #endregion

        #region Method
        public override async Task<IList<AnimalModel>> GetListAnimal()
        {
            var result = await _service.GetRandomListAnimal(50);
            return result.Cast<AnimalModel>().ToList();
          
        }
        #endregion

    }
}
