using System.Threading.Tasks;
using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineBase;
using System.Collections.ObjectModel;
using System.Collections;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class AutoBattleEngineGameTests
    {
        #region TestSetup
        AutoBattleEngine AutoBattleEngine;
        ObservableCollection<CharacterModel> Dataset = new ObservableCollection<CharacterModel>(CharacterIndexViewModel.Instance.Dataset);

        [SetUp]
        public void Setup()
        {

            AutoBattleEngine = new AutoBattleEngine();

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Clear();
            AutoBattleEngine.Battle.EngineSettings.MonsterList.Clear();
            AutoBattleEngine.Battle.EngineSettings.CurrentDefender = null;
            AutoBattleEngine.Battle.EngineSettings.CurrentAttacker = null;

            AutoBattleEngine.Battle.Round = new RoundEngine();
            AutoBattleEngine.Battle.Round.Turn = new TurnEngine();

            CharacterIndexViewModel.Instance.Dataset = new ObservableCollection<CharacterModel>(Dataset);


            //AutoBattleEngine.Battle.StartBattle(true);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
            CharacterIndexViewModel.Instance.Dataset = new ObservableCollection<CharacterModel>(Dataset);
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void AutoBattleEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattleEngine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AutoBattleEngine_Constructor_Valid_Battle_Round_Turn_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattleEngine;
            result.Battle = new BattleEngine();
            result.Battle.Round = new RoundEngine();
            result.Battle.Round.Turn = new TurnEngine();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region RunAutoBattle
        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Default_Should_Pass()
        {
            //Arrange

            CharacterIndexViewModel.Instance.Dataset = new ObservableCollection<CharacterModel>(Dataset);

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset
            //AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = oldRoundCountMax;

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_DetectInfinateLoop_Should_Return_False()
        {
            //Arrange

            // Trigger DetectInfinateLoop Loop
            var oldRoundCountMax = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount;
            AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = -1;

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset
            AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = oldRoundCountMax;

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_NewRound_Should_Return_True()
        {
            //Arrange

            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyMonsters = 1;
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Attack = 100,
                                Defense = 100,
                                Level = 1,
                                CurrentHealth = 111,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            var MonsterPlayerSue = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Attack = 1,
                    Defense = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    ExperienceRemaining = 1,
                    Name = "Sue",
                    ListOrder = 2,
                });

            AutoBattleEngine.Battle.EngineSettings.MonsterList.Add(MonsterPlayerSue);

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(false, result);
        }
        #endregion RunAutoBattle

        #region CreateCharacterParty

        [Test]
        public void AutoBattleEngine_CreateCharacterParty_Valid_Characters_CharacterIndex_None_Should_Create_6()
        {
            //Arrange
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            //Act
            var result = AutoBattleEngine.CreateCharacterParty();

            //Reset

            //Assert
            Assert.AreEqual(6, AutoBattleEngine.Battle.EngineSettings.CharacterList.Count);
        }

        [Test]
        public void AutoBattleEngine_CreateCharacterParty_Valid_Characters_Should_Assign_6()
        {
            //Assert.AreNotEqual(CharacterIndexViewModel.Instance.Dataset.Count, 0);
            CharacterIndexViewModel.Instance.Dataset = new ObservableCollection<CharacterModel>(Dataset);
            //Arrange
            var battleEngine = new AutoBattleEngine();
            //Act
            var result = battleEngine.CreateCharacterParty();

            //Reset

            //Assert
            Assert.AreEqual(6, AutoBattleEngine.Battle.EngineSettings.CharacterList.Count);
        }

       
        #endregion CreateCharacterParty   

        #region DetectInfinateLoop
        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_RoundCount_More_Than_Max_Should_Return_True()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.RoundCount = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount + 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_TurnCount_Count_More_Than_Max_Should_Return_True()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.TurnCount = AutoBattleEngine.Battle.EngineSettings.MaxTurnCount + 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_Valid_Counts_Less_Than_Max_Should_Return_false()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.TurnCount = AutoBattleEngine.Battle.EngineSettings.MaxTurnCount - 1;
            AutoBattleEngine.Battle.EngineSettings.BattleScore.RoundCount = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount - 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion 

        #region getBattleMessagesList
        [Test]
        public async Task AutoBattleEngine_getBattleMessagesList_ReturnsMessagesList()
        {
            var success = await AutoBattleEngine.RunAutoBattle();
            ObservableCollection<string> result = (ObservableCollection<string>)AutoBattleEngine.getBattleMessagesList();

            Assert.IsNotNull(success);
            Assert.IsNotEmpty(result);
        }
        #endregion
    }
}