using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    
    public partial class BeginGamePage : ContentPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BeginGamePage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Jump to the ThankYou page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ThankYouPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

    }
}