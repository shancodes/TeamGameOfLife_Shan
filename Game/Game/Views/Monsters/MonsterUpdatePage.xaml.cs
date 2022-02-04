using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using Game.GameRules;

namespace Game.Views
{
    /// <summary>
    /// Monster Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {
        // The Monster to create
        public GenericViewModel<MonsterModel> ViewModel { get; set; }
        private MonsterModel OriginalModel;
        private bool reset_started = false;

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        // Empty Constructor for UTs
        public MonsterUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
            this.OriginalModel = new MonsterModel(data.Data);
            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            _ = UpdatePageBindingContext();
        }

        /// <summary>
        /// Redo the Binding to cause a refresh
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageBindingContext()
        {
            // Temp store off the Difficulty
            var difficulty = this.ViewModel.Data.Difficulty;

            // Clear the Binding and reset it
            BindingContext = null;
            BindingContext = this.ViewModel;

            // This resets the Picker to -1 index, need to reset it back
            ViewModel.Data.Difficulty = difficulty;
            DifficultyPicker.SelectedItem = difficulty.ToMessage();

            return true;
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = new MonsterModel().ImageURI;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);

            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Helper Function that updates all the fields with current values from ViewModel.Data
        /// </summary>
        private void UpdateUIElements()
        {
            Name_Entry.Text = ViewModel.Data.Name;
            Description_Entry.Text = ViewModel.Data.Description;
            AttackValue.Text = string.Format("{0}", ViewModel.Data.Attack);
            DifficultyPicker.SelectedItem = ViewModel.Data.Difficulty.ToMessage();
        }



        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            this.ViewModel.Data.Update(OriginalModel);
            _ = await Navigation.PopModalAsync();
        }

        ///// <summary>
        ///// Change the Level Picker
        ///// </summary>
        //public void ManageHealth()
        //{
        //    // Roll for new HP
        //    ViewModel.Data.MaxHealth = RandomPlayerHelper.GetHealth(ViewModel.Data.Level);

        //    // Show the Result
        //    MaxHealthValue.Text = ViewModel.Data.MaxHealth.ToString();
        //}

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


        /// <summary>
        /// Input Validation for Name
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void EntryName_TextChanged(object Sender, TextChangedEventArgs e)
        {
           SetUpdateVisibility();
        }

        /// <summary>
        /// Input Validation for Description
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void EntryDescription_TextChanged(object Sender, TextChangedEventArgs e)
        {
            SetUpdateVisibility();
        }

        /// <summary>
        /// Disable Update button when Name and Description entries are empty
        /// </summary>
        private void SetUpdateVisibility()
        {
            if (string.IsNullOrEmpty(Name_Entry.Text) || string.IsNullOrEmpty(Description_Entry.Text))
            {
                Update.IsEnabled = false;
                return;
            }

            Update.IsEnabled = true;
        }

        /// <summary>
        /// Catch the change to the Stepper for Attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AttackValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the Stepper for Defense
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DefenseValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the Stepper for Speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = String.Format("{0}", e.NewValue);
        }


        ///// <summary>
        ///// Randomize the Monster, keep the level the same
        ///// </summary>
        ///// <returns></returns>
        //public bool RandomizeMonster()
        //{
        //    // Randomize Name
        //    ViewModel.Data.Name = RandomPlayerHelper.GetMonsterName();
        //    ViewModel.Data.Description = RandomPlayerHelper.GetMonsterDescription();

        //    // Randomize the Attributes
        //    ViewModel.Data.Attack = RandomPlayerHelper.GetAbilityValue();
        //    ViewModel.Data.Speed = RandomPlayerHelper.GetAbilityValue();
        //    ViewModel.Data.Defense = RandomPlayerHelper.GetAbilityValue();

        //    ViewModel.Data.Difficulty = RandomPlayerHelper.GetMonsterDifficultyValue();

        //    ViewModel.Data.ImageURI = RandomPlayerHelper.GetMonsterImage();

        //    ViewModel.Data.UniqueItem = RandomPlayerHelper.GetMonsterUniqueItem();

        //    _ = UpdatePageBindingContext();

        //    return true;
        //}
    }
}