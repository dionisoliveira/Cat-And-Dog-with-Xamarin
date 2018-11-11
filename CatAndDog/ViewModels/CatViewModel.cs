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
using System.Net.Http;
using System.IO;

namespace CatAndDog
{
    public class CatViewModel : AnimalBaseViewModel
    {
        #region Fields
        private ICatService _service =DependencyService.Get<ICatService>();
        #endregion

        #region Command

        public Command LoadItemsCommand { get; set; }

        #endregion

        #region Constructor

        public CatViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Animal>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


        }

        #endregion

        #region Method

      
        public override async Task<IList<AnimalModel>> GetListAnimal()
		{
            var result =   await _service.GetRandomListAnimal(25);
  
            return result.Cast<AnimalModel>().ToList();
		}
     

		 #endregion
    }

}
