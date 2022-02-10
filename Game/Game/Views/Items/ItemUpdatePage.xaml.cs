using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemUpdatePage : ContentPage
    {
        /// <summary>
        /// View Model for Item
        /// </summary>
        public readonly GenericViewModel<ItemModel> ViewModel;
        private ItemModel OriginalModel;

        // Empty Constructor for Tests
        public ItemUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public ItemUpdatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();
            this.OriginalModel = new ItemModel(data.Data);

            BindingContext = this.ViewModel = data;

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = data.Data.Location.ToMessage();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            this.ViewModel.Data.Update(OriginalModel);
            _ = await Navigation.PopModalAsync();
        }

        public bool UpdateButton_State()
        {
            return Update.IsEnabled;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
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

        /// <summary>
        /// Helper Function that updates all the fields with current values from ViewModel.Data
        /// </summary>
        private void UpdateUIElements()
        {
            Name_Entry.Text = ViewModel.Data.Name;
            Description_entry.Text = ViewModel.Data.Description;

            LocationPicker.SelectedItem = ViewModel.Data.Location.ToMessage();
            AttributePicker.SelectedIndex = AttributeEnumHelper.GetListCharacter.IndexOf(ViewModel.Data.Attribute.ToString());

            ImageEntry.Text = ViewModel.Data.ImageURI;
            RangeValue.Text = string.Format("{0}", ViewModel.Data.Range);
            DamageValue.Text = string.Format("{0}", ViewModel.Data.Damage);
            ValueValue.Text = string.Format("{0}", ViewModel.Data.Value);
        }

        /// <summary>
        /// Catch the change to the Stepper for Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Range_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            RangeValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Damage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Damage_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DamageValue.Text = string.Format("{0}", e.NewValue);
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

        private void SetUpdateVisibility()
        {
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                Update.IsEnabled = false;
                return;
            }

            Update.IsEnabled = true;
        }
    }
}