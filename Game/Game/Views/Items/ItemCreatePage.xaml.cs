using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        public ItemCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create an Item";

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = ViewModel.Data.Location.ToString();
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            //Input validation for location picker
            if (ViewModel.Data.Location == ItemLocationEnum.Unknown)
            {
                return;
            }

            //input validation for Attribute picker
            if (ViewModel.Data.Attribute == AttributeEnum.Unknown)
            {
                return;
            }

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopModalAsync();
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
        /// Input validation for Name
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void EntryName_TextChanged(object Sender, TextChangedEventArgs e)
        {
            SetCreateVisibility();
        }

        /// <summary>
        /// Input validation for description
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void EntryDescription_TextChanged(object Sender, TextChangedEventArgs e)
        {
            SetCreateVisibility();
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
        /// function to check if Name and Description is empty field
        /// </summary>
        private void SetCreateVisibility()
        {
            if (string.IsNullOrEmpty(Name_Entry.Text) || string.IsNullOrEmpty(Description_entry.Text))
            {
                CreateButton.IsEnabled = false;
                return;
            }

            CreateButton.IsEnabled = true;
        }
    }
}