using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Score Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreUpdatePage : ContentPage
    {
        // View Model for Score
        public readonly GenericViewModel<ScoreModel> ViewModel;
        private ScoreModel OriginalModel;

        // Constructor for Unit Testing
        public ScoreUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor that takes and existing data Score
        /// </summary>
        public ScoreUpdatePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();
            this.OriginalModel = new ScoreModel(data.Data);

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Update", ViewModel.Data);
            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Helper Function that updates all the fields with current values from ViewModel.Data
        /// </summary>
        private void UpdateUIElements()
        {
            Name_Entry.Text = ViewModel.Data.Name.ToString();
            Score_Entry.Text = ViewModel.Data.ScoreTotal.ToString();
            GameTime_Entry.Text = ViewModel.Data.GameDate.ToString();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Reset the fields to original values before update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Reset_Clicked(object sender, EventArgs e)
        {
            this.ViewModel.Data.Update(OriginalModel);
            MessagingCenter.Send(this, "Update", ViewModel.Data);
            UpdateUIElements();
        }
    }
}