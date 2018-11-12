using System;

using Xamarin.Forms;

namespace CatAndDog
{
    public partial class DogPage : ContentPage
    {

        #region Fields
        DogViewModel viewModel;
        #endregion


        #region Constructor
        public DogPage()
        {
            InitializeComponent();


            BindingContext = viewModel = new DogViewModel();

        }
        #endregion

        #region Method

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await viewModel.ExecuteLoadItemsCommand();
                });
            }
        }
        #endregion
    }
}
