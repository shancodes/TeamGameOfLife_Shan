using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Game.Engine.EngineModels;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// Selecting Characters for the Game
    /// 
    /// TODO: Team
    /// Mike's game allows duplicate characters in a party (6 Mikes can all fight)
    /// If you do not allow duplicates, change the code below
    /// Instead of using the database list directly make a copy of it in the viewmodel
    /// Then have on select of the database remove the character from that list and add to the part list
    /// Have select from the party list remove it from the party list and add it to the database list
    ///
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickCharactersPage : ContentPage
    {

        // Empty Constructor for UTs
        public PickCharactersPage(bool UnitTest) { }

        public EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public PickCharactersPage()
        {
            InitializeComponent();

            BindingContext = BattleEngineViewModel.Instance;
            //BindingContext = BattleEngineViewModel.Instance;

            // Clear the Database List and the Party List to start
            BattleEngineViewModel.Instance.PartyCharacterList.Clear();

            UpdateNextButtonState();
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDatabaseCharacterItemSelected(object sender, SelectionChangedEventArgs args)
        {
            if (args.CurrentSelection.Count == 0)
            {
                return;
            }
            CharacterModel data = args.CurrentSelection[0] as CharacterModel;

            // Manually deselect Character.
            CharactersListView.SelectedItem = null;

            // Don't add more than the party max
            if (BattleEngineViewModel.Instance.PartyCharacterList.Count() < BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Add(data);
            }

            UpdateNextButtonState();
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnPartyCharacterItemSelected(object sender, SelectionChangedEventArgs args)
        {
            if (args.CurrentSelection.Count == 0)
            {
                return;
            }
            CharacterModel data = args.CurrentSelection[0] as CharacterModel;

            // Manually deselect Character.
            PartyListView.SelectedItem = null;

            // Remove the character from the list
            _ = BattleEngineViewModel.Instance.PartyCharacterList.Remove(data);

            UpdateNextButtonState();
        }

        /// <summary>
        /// Next Button is based on the count
        /// 
        /// If no selected characters, disable
        /// 
        /// Show the Count of the party
        /// 
        /// </summary>
        public void UpdateNextButtonState()
        {
            // If no characters disable Next button
            BeginBattleButton.IsEnabled = true;

            var currentCount = BattleEngineViewModel.Instance.PartyCharacterList.Count();
            if (currentCount == 0)
            {
                BeginBattleButton.IsEnabled = false;
            }

            //PartyCountLabel.Text = currentCount.ToString();
        }

        /// <summary>
        /// Jump to the Battle
        /// 
        /// Its Modal because don't want user to come back...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BattleButton_Clicked(object sender, EventArgs e)
        {  
            CreateEngineCharacterList();

            await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
            _ = await Navigation.PopAsync();
        }

        /// <summary>
        /// Clear out the old list and make the new list
        /// </summary>
        public void CreateEngineCharacterList()
        {
            // Clear the currett list
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();

            // Load the Characters into the Engine
            foreach (var data in BattleEngineViewModel.Instance.PartyCharacterList)
            {
                data.CurrentHealth = data.GetMaxHealthTotal;
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            }
        }

        /// <summary>
        /// Setting background color to Default
        /// </summary>
        public void UnsetUserDifficultyStyles()
        {
            NoobButton.BackgroundColor = default;
            JoeButton.BackgroundColor = default;
            ProButton.BackgroundColor = default;
        }

        /// <summary>
        /// Set Background color of the button to Default
        /// Set User Difficulty 
        /// Set the Background color of the selected button to Green
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NoobButton_Clicked(object sender, EventArgs e)
        {
            UnsetUserDifficultyStyles();
            EngineSettings.userDifficulty = EngineSettingsModel.UserDifficultyEnum.Noob;
            NoobButton.BackgroundColor = Color.Green;
        }

        /// <summary>
        /// Set Background color of the button to Default
        /// Set User Difficulty 
        /// Set the Background color of the selected button to Green
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void JoeButton_Clicked(object sender, EventArgs e)
        {
            UnsetUserDifficultyStyles();
            EngineSettings.userDifficulty = EngineSettingsModel.UserDifficultyEnum.Joe;
            JoeButton.BackgroundColor = Color.Green;

        }

        /// <summary>
        /// Set Background color of the button to Default
        /// Set User Difficulty 
        /// Set the Background color of the selected button to Green
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProButton_Clicked(object sender, EventArgs e)
        {
            UnsetUserDifficultyStyles();
            EngineSettings.userDifficulty = EngineSettingsModel.UserDifficultyEnum.Pro;
            ProButton.BackgroundColor = Color.Green;
        }
    }
}