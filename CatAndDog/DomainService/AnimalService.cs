using System;

using Xamarin.Forms;

namespace CatAndDog.DomainService
{
    public class AnimalService : ContentPage
    {
        public AnimalService()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

