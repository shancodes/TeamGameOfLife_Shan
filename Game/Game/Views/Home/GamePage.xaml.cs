using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GamePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        /// <summary>
        /// Jump to the battle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DungeonButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BeginGamePage());
        }

        /// <summary>
        /// Jump to the Village
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void VillageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VillagePage());
        }

        /// <summary>
        /// Jump to the autobattle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AutobattleButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AutoBattlePage());
        }
    }
}