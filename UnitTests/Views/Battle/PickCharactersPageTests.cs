using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;
using Game.GameRules;

namespace UnitTests.Views
{
    [TestFixture]
    public class PickCharactersPageTests : PickCharactersPage
    {
        App app;
        PickCharactersPage page;

        public PickCharactersPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new PickCharactersPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        /// <summary>
        /// Test for Pick Characters Page Const
        /// </summary>
        [Test]
        public void PickCharactersPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for Pick Charcaters Page Const
        /// </summary>
        [Test]
        public void PickCharactersPage_Constructor_UT_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PickCharactersPage(false);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test for Battle Button Clicked
        /// </summary>
        [Test]
        public void PickCharactersPage_BattleButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.BattleButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test for CreateEngineCharacterList
        /// </summary>
        [Test]
        public void PickCharactersPage_CreateEngineCharacterList_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            BattleEngineViewModel.Instance.PartyCharacterList = new ObservableCollection<CharacterModel>();
            BattleEngineViewModel.Instance.PartyCharacterList.Add(new CharacterModel());

            // Act
            page.CreateEngineCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //[Test]
        //public void PickCharactersPage_OnApperaing_Default_Should_Pass()
        //{
        //    // Arrange
        //    BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
        //    BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

        //    BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
        //    BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

        //    BattleEngineViewModel.Instance.PartyCharacterList = new ObservableCollection<CharacterModel>();
        //    BattleEngineViewModel.Instance.PartyCharacterList.Add(new CharacterModel());

        //    var temp = page.EngineViewModel.Engine;

        //    page.UpdateNextButtonState();

        //    // Act
        //    OnAppearing();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        /// <summary>
        /// Test for UpdateNextButton State
        /// </summary>
        [Test]
        public void PickCharactersPage_UpdateButtonState_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.UpdateNextButtonState();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test for Selected Characters List
        /// </summary>
        [Test]
        public void PickCharactersPage_OnPartyCharacterItemSelected_Default_Should_Pass()
        {
            // Arrange
            CollectionView cv = (CollectionView)page.FindByName("PartyListView");

            // Act
            cv.SelectedItem = new CharacterModel();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test for Selected character list Invalid
        /// </summary>
        [Test]
        public void PickCharactersPage_OnPartyCharacterItemSelected_InValid_Should_Pass()
        {
            // Arrange
            CollectionView cv = (CollectionView)page.FindByName("PartyListView");

            // Act
            cv.SelectedItem = null;

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test for Selecting Characters
        /// </summary>
        [Test]
        public void PickCharactersPage_OnDatabaseCharacterItemSelected_Default_Should_Pass()
        {
            //// Arrange
            var selectedCharacter = new CharacterModel();
            CollectionView cv = (CollectionView) page.FindByName("CharactersListView");

            //// Act
            /// Trigger OnDatabaseCharacterItemSelected by setting SelectedItem on CollectionView
            cv.SelectedItem = selectedCharacter;

            //// Reset

            //// Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test for Selecting Characters Invalid
        /// </summary>
        [Test]
        public void PickCharactersPage_OnDatabaseCharacterItemSelected_InValid_Should_Pass()
        {
            // Arrange
            CollectionView CharactersListView = (CollectionView)page.FindByName("CharactersListView");
            var list = new ObservableCollection<CharacterModel>(DefaultData.LoadData(new CharacterModel()));
            CharactersListView.ItemsSource = list;

            // Act

            // Triggers the OnCollectionViewSelectionChanged
            CharactersListView.SelectedItem = list[0];

            // Reset
            CharactersListView.SelectedItem = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Tests for Noob Button Clicked
        /// </summary>
        [Test]
        public void PickCharactersPage_On_NoobClicked_Should_Pass() {
            // Arrange
            var btn = (Button) page.FindByName("NoobButton");

            //Act
            page.NoobButton_Clicked(null, new System.EventArgs());
            //Reset

            //Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests for Joe Button Clicked
        /// </summary>
        [Test]
        public void PickCharactersPage_On_JoeClicked_Should_Pass() {
            // Arrange
            var btn = (Button)page.FindByName("JoeButton");

            //Act
            page.JoeButton_Clicked(null, new System.EventArgs());
            //Reset

            //Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests for Pro Button Clicked
        /// </summary>
        [Test]
        public void PickCharactersPage_On_ProClicked_Should_Pass() {
            // Arrange
            var btn = (Button)page.FindByName("Pro");

            //Act
            page.ProButton_Clicked(null, new System.EventArgs());
            //Reset

            //Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests for Unset User Difficulty
        /// </summary>
        [Test]
        public void PickCharactersPage_UnsetUserDifficultyStyles_Should_Pass()
        {
            //Arrange
            //Act
            page.UnsetUserDifficultyStyles();
            //Reset

            //Assert
            Assert.IsTrue(true);
        }
    }
}