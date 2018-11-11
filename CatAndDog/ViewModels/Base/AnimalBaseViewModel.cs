using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Security.Cryptography.X509Certificates;
using CatAndDogService.Model;
using System.Collections.Generic;
using System.Linq;

namespace CatAndDog.ViewModels
{
    public abstract class AnimalBaseViewModel : BaseViewModel<Animal>
    {
       

    #region Command

    public Command LoadItemsCommand { get; set; }

    #endregion

    #region Constructor
        public AnimalBaseViewModel()
    {
      
        Items = new ObservableCollection<Animal>();

        LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


    }

        #endregion

    #region Method
        /// <summary>
        /// Create generic method for animal
        /// </summary>
        /// <returns>The list animal.</returns>
       public abstract  Task<IList<AnimalModel>> GetListAnimal();
    
        /// <summary>
        /// Executes the load items command.
        /// </summary>
        /// <returns>The load items command.</returns>
    public virtual async Task ExecuteLoadItemsCommand()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
                var result = await GetListAnimal();
               var list = result.ToList().Select(p =>
            {
                var animal = new Animal()
                {
                    Id = p.Id,
                    Url = p.Url,
                    Image = ImageSource.FromUri(new Uri(p.Url))
                };

                return animal;

            }).ToList();

            Items = new ObservableCollection<Animal>(list);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }

           
    }



    #endregion
}
}
