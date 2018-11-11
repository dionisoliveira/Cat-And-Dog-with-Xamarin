using System;

using Xamarin.Forms;

namespace CatAndDog
{
    public partial class DogPage : ContentPage
    {
        DogViewModel viewModel;

        public DogPage()
        {
            InitializeComponent();


            BindingContext =viewModel = new DogViewModel();

        }

       
      

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                Device.BeginInvokeOnMainThread(async ()=>
                {
                    await viewModel.ExecuteLoadItemsCommand();
                });
            }
        }
    }
}
