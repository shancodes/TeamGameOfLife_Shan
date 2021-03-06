using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineBase;


using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.Engine.EngineBase;
using System.Collections.Generic;
using static Game.Engine.EngineModels.EngineSettingsModel;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class RoundEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new();

            Engine.Round = new RoundEngine
            {
                Turn = new TurnEngine()
            };
            _ = Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            //Engine.StartBattle(true);   
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void RoundEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange
            _ = Engine.Round.ClearLists();

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region OrderPlayListByTurnOrder
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Speed_Higher_Should_Be_Z()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Level_Higher_Should_Be_Z()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Experience_Higher_Should_Be_Z()
        {
            // Arrange

            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 100,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10,
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_ListOrder_Should_Be_1()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "A",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "A",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual(1, result[0].ListOrder);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Name_A_Z_Should_Be_Z()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "ZZ",
                ListOrder = 10
            };

            CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }
        #endregion OrderPlayListByTurnOrder

        #region GetItemFromPoolIfBetter

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_Location_Empty_Should_Fail()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Feet };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Feet };

            _ = await ItemIndexViewModel.Instance.CreateAsync(item1);
            _ = await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.Head = null;

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act

            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.Feet);    // The 2nd item is better, so did they swap?
        }

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_Pool_Empty_Should_Fail()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Head };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Head };

            _ = await ItemIndexViewModel.Instance.CreateAsync(item1);
            _ = await ItemIndexViewModel.Instance.CreateAsync(item2);

            //Engine.EngineSettings.ItemPool.Add(item1);
            //Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            _ = Character.AddItem(ItemLocationEnum.Head, item2.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        #endregion GetItemFromPoolIfBetter

        #region PickupItemsFromPool
        //[Test]
        //public void RoundEngine_PickupItemsFromPool_Valid_Default_Should_Pass()
        //{
        //    // Arrange
        //    var Character = new CharacterModel
        //    {
        //        Speed = 20,
        //        Level = 1,
        //        CurrentHealth = 1,
        //        ExperienceTotal = 1,
        //        Name = "Z",
        //        ListOrder = 1,
        //        Guid = "me"
        //    };

        //    // Add each model here to warm up and load it.
        //    _ = Game.Helpers.DataSetsHelper.WarmUp();

        //    var CharacterPlayer = new PlayerInfoModel(Character);
        //    Engine.EngineSettings.CharacterList.Clear();
        //    Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

        //    // Make the List
        //    Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

        //    // Act
        //    var result = Engine.Round.PickupItemsFromPool(CharacterPlayer);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion PickupItemsFromPool

        #region EndRound
        [Test]
        public void RoundEngine_EndRound_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.Round.EndRound();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion EndRound

        #region RoundNextTurn
        [Test]
        public void RoundEngine_RoundNextTurn_Valid_No_Characters_Should_Return_GameOver()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Characer",
                ListOrder = 1,
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset
            Engine.EngineSettings.CharacterList.Clear();
            _ = Engine.Round.ClearLists();

            // Assert
            Assert.AreEqual(RoundEnum.GameOver, result);
        }

        [Test]
        public void RoundEngine_RoundNextTurn_Valid_No_Monsters_Should_Return_NewRound()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Characer",
                ListOrder = 1,
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            //Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset
            _ = Engine.Round.ClearLists();

            // Assert
            Assert.AreEqual(RoundEnum.NewRound, result);
        }

        [Test]
        public void RoundEngine_RoundNextTurn_Valid_Characters_Monsters_Should_Return_NewRound()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Character",
                ListOrder = 1,
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(Character);
            Engine.EngineSettings.CurrentAttacker.PlayerType = PlayerTypeEnum.Character;

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset
            _ = Engine.Round.ClearLists();
            Engine.EngineSettings.CurrentAttacker = null;

            // Assert
            Assert.AreEqual(RoundEnum.NextTurn, result);
        }
        #endregion RoundNextTurn

        #region GetNextPlayerInList

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Sue_Should_Return_Monster()
        {
            // Arrange
            _ = Engine.Round.ClearLists();

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Monster_Should_Return_Null()
        {
            // Arrange
            _ = Engine.Round.ClearLists();
            Engine.EngineSettings.PlayerList.Clear();

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset


            // Assert
            Assert.AreEqual(null, result);
        }

        #endregion GetNextPlayerInList

        #region PlayerList
        //[Test]
        //public void RoundEngine_PlayerList_Valid_Default_Should_Pass()
        //{
        //    // Act
        //    var result = Engine.Round.PlayerList();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result.Any());
        //}
        #endregion PlayerList

        #region SwapCharacterItem
        [Test]
        public void RoundEngine_SwapCharacterItem_Valid_Default_Should_Pass()
        {
            // Arrange 
            _ = Engine.Round.ClearLists();
            Engine.EngineSettings.PlayerList.Clear();

            // Act
            var result = Engine.Round.SwapCharacterItem(null, ItemLocationEnum.Head, null);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SwapCharacterItem

        #region GetItemFromPoolIfBetter
        [Test]
        public void RoundEngine_GetItemFromPoolIfBetter_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(null, ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Added unit test to swap items with item pool items
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_Valid_Swap_Should_Pass()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Finger, Damage = 10 };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Finger, Damage = 10 };
            var item3 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Finger, Damage = 5 };

            _ = await ItemIndexViewModel.Instance.CreateAsync(item1);
            _ = await ItemIndexViewModel.Instance.CreateAsync(item2);
            _ = await ItemIndexViewModel.Instance.CreateAsync(item3);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);
            Engine.EngineSettings.ItemPool.Add(item3);

            // Put the Item on the Character
            _ = Character.AddItem(ItemLocationEnum.LeftFinger, item3.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            CharacterPlayer.CurrentHealth = 5;
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.LeftFinger);    // The 2nd item is better, so did they swap?
        }
        #endregion GetItemFromPoolIfBetter

        #region RemoveDeadPlayersFromList
        [Test]
        public void RoundEngine_RemoveDeadPlayersFromList_Valid_Default_Should_Pass()
        {
            // Arrange 
            _ = Engine.Round.ClearLists();
            Engine.EngineSettings.PlayerList.Clear();

            // Act
            var result = Engine.Round.RemoveDeadPlayersFromList();

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count);
        }
        #endregion RemoveDeadPlayersFromList

        #region PickupItemsFromPool
        [Test]
        public void RoundEngine_PickupItemsFromPool_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.PickupItemsFromPool(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion PickupItemsFromPool

        #region GetNextPlayerTurn
        [Test]
        public void RoundEngine_GetNextPlayerTurn_Valid_Default_Should_Pass()
        {
            // Arrange 
            _ = Engine.Round.ClearLists();

            // Act
            var result = Engine.Round.GetNextPlayerTurn();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion GetNextPlayerTurn

        #region AddMonstersToRound
        [Test]
        public void RoundEngine_AddMonstersToRound_Valid_Should_Pass()
        {
            RoundEngine e = new RoundEngine();
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            e.EngineSettings.MonsterList.Clear();
            e.EngineSettings.MonsterList.Add(MonsterPlayer);
            e.EngineSettings.CharacterList.Clear();

            e.EngineSettings.MaxNumberPartyMonsters = 10;

            // Act
            var result = Engine.Round.AddMonstersToRound();

            // Reset

            // Assert
            Assert.AreEqual(10, result);
        }
        #endregion AddMonstersToRound

        #region AddUserCreatedMonsters
        [Test]
        public void RoundEngine_AddUserCreatedMonsters_Valid_Should_Pass()
        {
            // Arrange
            var MonsterList = MonsterIndexViewModel.Instance.Dataset;

            // Act
            MonsterIndexViewModel.Instance.Dataset.Clear();

            RoundEngine roundEngine = new RoundEngine();
            roundEngine.AddUserCreatedMonsters();

            var result = MonsterIndexViewModel.Instance.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }
        #endregion AddUserCreatedMonsters

        #region setMonsterList
        [Test]
        public void RoundEngine_setMonstersList_Valid_Should_Pass()
        {
            // Arrange

            // Act
            RoundEngine roundEngine = new RoundEngine();

            roundEngine.setMonstersList(UserDifficultyEnum.Pro);

            var result = roundEngine.DbMonsterList;

            // Reset

            // Assert
            Assert.AreEqual(8, roundEngine.DbMonsterList.Count);
            int firstDifficulty = (int) result[0].Difficulty;
            int lastDifficulty = (int)result[7].Difficulty;
            Assert.GreaterOrEqual(lastDifficulty, firstDifficulty);
        }
        #endregion setMonsterList
    }
}