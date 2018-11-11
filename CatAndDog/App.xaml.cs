using System;

using Xamarin.Forms;
using CatAndDogService.Services.Interface;
using CatAndDogService.Services;

namespace CatAndDog
{
    public partial class App : Application
    {
       
        public App()
        {


            InitializeComponent();

            RegisterIoC();

            if (Device.RuntimePlatform == Device.iOS)
               MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());

           
        }

        /// <summary>
        /// Register IoC
        /// </summary>
        private void RegisterIoC()
        {
            DependencyService.Register<ICatService, CatService>();
            DependencyService.Register<IDogService, DogService>();
        }
    }
}
