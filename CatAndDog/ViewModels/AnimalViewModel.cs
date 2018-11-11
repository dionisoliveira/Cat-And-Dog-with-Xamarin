using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CatAndDog
{
    public class AnimalViewModel : BaseViewModel
    {
        public ObservableCollection<Animal> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AnimalViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Animal>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

         
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
             
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
    }
}
