using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineInterfaces;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoBattlePage : ContentPage
    {
        // Hold the Engine, so it can be swapped out for unit testing
        public IAutoBattleInterface AutoBattle = BattleEngineViewModel.Instance.AutoBattleEngine;

        /// <summary>
        /// Constructor
        /// </summary>
        public AutoBattlePage()
        {
            InitializeComponent();
            AutoBattleFrame.IsVisible = false; 
        }

        /// <summary>
        /// Starts the Auto Battle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AutobattleButton_Clicked(object sender, EventArgs e)
        {
            var BattleStartMessage = "Auto Battle Started..";

            BattleMessageValue.Text = BattleStartMessage;
            // Call into Auto Battle from here to do the Battle...

            // To See Level UP happening, a character needs to be close to the next level
            var Character = new CharacterModel
            {
                ExperienceTotal = 300,    // Enough for next level
                Name = "Fire Fighter",
                Speed = 100,    // Go first
            };

            var CharacterPlayer = new PlayerInfoModel(Character);

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            _ = await AutoBattle.RunAutoBattle();

            var BattleMessage = string.Format("Done {0} Rounds", AutoBattle.Battle.EngineSettings.BattleScore.RoundCount);

            BattleMessageValue.Text = BattleMessage;

            AutobattleImage.Source = "fire_princess.gif";
        }

        /// <summary>
        /// Displays all the background battle messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ViewBattleInfo_Clicked(object sender, EventArgs e)
        {
            AutoBattleFrame.IsVisible = true;
            battleMessagesList.ItemsSource = AutoBattle.getBattleMessagesList();
        }
    }
}