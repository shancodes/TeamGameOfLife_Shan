using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRoundPage : ContentPage
    {
        // This uses the Instance so it can be shared with other Battle Pages as needed
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
        string difficulty_text;

        /// <summary>
        /// Constructor
        /// </summary>
        public NewRoundPage()
        {
            InitializeComponent();

            // Draw the Characters
            foreach (var data in EngineViewModel.Engine.EngineSettings.CharacterList)
            {
                PartyListFrame.Children.Add(CreatePlayerDisplayBox(data));
            }

            // Draw the Monsters
            foreach (var data in EngineViewModel.Engine.EngineSettings.MonsterList)
            {
                MonsterListFrame.Children.Add(CreatePlayerDisplayBox(data));
            }

        }

        /// <summary>
        /// Start next Round, returning to the battle screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BeginButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.MapNext;
            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreatePlayerDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }
            
            switch(data.Difficulty)
            {
                case DifficultyEnum.Average:
                    difficulty_text = "Average";
                    break;
                case DifficultyEnum.Difficult:
                    difficulty_text = "Difficult";
                    break;
                case DifficultyEnum.Easy:
                    difficulty_text = "Easy";
                    break;
                case DifficultyEnum.Hard:
                    difficulty_text = "Hard";
                    break;
                case DifficultyEnum.Impossible:
                    difficulty_text = "Impossible";
                    break;
                case DifficultyEnum.Unknown:
                    difficulty_text = "Unknown";
                    break;
            }
            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                Source = data.ImageURI
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                TextColor = Color.Wheat,
                MaxLines = 1,
            };

            // Add the HP
            var PlayerHPLabel = new Label
            {
                Text = "HP : " + data.MaxHealth,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
                TextColor = Color.Wheat
            };

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
                TextColor = Color.Wheat
            };

            var PlayerDifficultyLabel = new Label()
            {
                Text = difficulty_text,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
                TextColor = Color.Wheat
            };

            if(data.PlayerType == PlayerTypeEnum.Character)
            {
                // Put the Image Button and Text inside a layout
                var PlayerStack = new StackLayout
                {
                    Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                    HorizontalOptions = LayoutOptions.Center,
                    Padding = 0,
                    Spacing = 0,
                    Children = {
                    PlayerImage,
                    PlayerNameLabel,
                    PlayerLevelLabel,
                    PlayerHPLabel,
                },
                };
                return PlayerStack;
            }
            else
            {
                var MonsterStack = new StackLayout
                {
                    Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                    HorizontalOptions = LayoutOptions.Center,
                    Padding = 0,
                    Spacing = 0,
                    Children = {
                    PlayerImage,
                    PlayerNameLabel,
                    PlayerDifficultyLabel,
                },
                };
                return MonsterStack;
            }
        }
    }
}