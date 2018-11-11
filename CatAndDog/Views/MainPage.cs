using System;

using Xamarin.Forms;
using CatAndDogService.Services.Interface;

namespace CatAndDog
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page catPage, dogPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:

                    catPage= new NavigationPage(new CatPage())
                    {
                        
                        Title = "Cat"
                    };
                    dogPage = new NavigationPage(new DogPage()
                    {
                        Title = "Dog"
                    });

                 
                    break;
                default:
                    catPage = new CatPage()
                    {

                        Title = "Cat"
                    };
                    dogPage = new DogPage()
                    {
                        Title = "Dog"
                    };
                   
                  
                    break;
            }

       

            Children.Add(catPage);
            Children.Add(dogPage);
         

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
