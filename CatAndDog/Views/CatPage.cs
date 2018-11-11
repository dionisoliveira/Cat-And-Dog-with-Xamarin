using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using CatAndDogService.Services.Interface;
using CatAndDogService.Model;

namespace CatAndDog
{
    public partial class CatPage : ContentPage
    {

        #region Fields

        CatViewModel viewModel;

        #endregion


        #region Construtor
        public CatPage()
        {
            InitializeComponent();


            BindingContext = viewModel = new CatViewModel();
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
