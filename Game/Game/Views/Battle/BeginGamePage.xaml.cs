using Game.Models;
using Game.ViewModels;
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
        /// Jump to the PickCharacters page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void PickUpCharacterPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        /// <summary>
        /// funtion to redirect player to the thank you page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ThankyouButtonClickedAsync(object sender, EventArgs e)
        {
            //BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
            BattlePage thankyoupage = new BattlePage();
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
            await Navigation.PushModalAsync(new NavigationPage(thankyoupage));
            //ShowBattleModeUIElements();
            _ = await Navigation.PopAsync();

        }

        public async void BattleMapClickedAsync(object sender, EventArgs e)
        {
            //BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
            BattlePage mapgridpage = new BattlePage();
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.MapNext;
            await Navigation.PushModalAsync(new NavigationPage(mapgridpage));
            //ShowBattleModeUIElements();
            _ = await Navigation.PopAsync();

        }

        /// <summary>
        /// Start next Round, returning to the battle screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AutoAssignButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickItemsPage());
        }

        /// <summary>
        /// Show the Round Over page
        /// 
        /// Round Over is where characters get items
        /// 
        /// </summary>
        private async void RoundOverPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoundOverPage());
        }
    }
}