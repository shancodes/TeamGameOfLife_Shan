using NUnit.Framework;

using Game.Models;
using System.Threading.Tasks;
using Game.ViewModels;
using Game.Helpers;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        [SetUp]
        public void Setup()
        {
            // Put seed data into the system for all tests
            _ = BattleEngineViewModel.Instance.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            _ = BattleEngineViewModel.Instance.Engine.StartBattle(false);

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert


            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_Scenario_1_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      A character named Mike dies in the first round, but rest of the
            *      characters fight longer
            *    
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create a list of charcters and add character Mike to it, total 3 characters
            *      Set Mike's speed to -1 so he is really slow
            *      Set Mike's Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *      set the speed of other characters to be high and current total, experience remainng and 
            *      experience total as high
            *  
            *      Startup Battle
            *      Run Auto Battle
            *      set MaxRoundCount as 1, to check what happens after first round
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned False since MaxRoundCount is 1and characters are stronger to advance 2nd round
            *      Verify Mike is not in the Player List
            *      Verify other players are in the list
            *      Verify Round Count of player after round 1 is 2, without Mike
            *  
            */

            //Arrange
            // Always roll a 1
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);

            EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount = 0;
            EngineViewModel.Engine.EngineSettings.MaxRoundCount = 1;

            // Set Character Conditions
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 3;
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyMonsters = 6;

            var CharacterPlayerMike = new PlayerInfoModel(
            new CharacterModel
            {
                Speed = -1, // Will go last...
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                ExperienceRemaining = 1,
                Name = "Mike",
            });
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            
            var CharacterPlayerJim = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 100,
                    Level = 1,
                    CurrentHealth = 100,
                    ExperienceTotal = 10,
                    ExperienceRemaining = 10,
                    Name = "Jim",
                    PrimaryHand = "Long Flame Sword"
                });
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerJim);

            var CharacterPlayerPam = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 100, 
                    Level = 2,
                    CurrentHealth = 100,
                    ExperienceTotal = 10,
                    ExperienceRemaining = 10,
                    Name = "Pam",
                    PrimaryHand = "Long Flame Sword"
                });
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerPam);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.CriticalHit;
            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.MaxRoundCount = 100;
            _ = DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(true, EngineViewModel.Engine.EngineSettings.CharacterList.Count == 2);
        }
        #endregion Scenario1

        #region Scenario2
        [Test]
        public async Task HackathonScenario_Scenario_2_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *   2
            *    
            * Description: 
            *   Character Doug always misses
            * 
            * Changes Required (Classes, Methods etc.) List Files, Methods, and Describe Changes: 
            *   No Code changes requied 
            * 
            * Test Algrorithm:
            *   Create Character named Doug along with 2 more characters
            *   Set Doug hit status to always miss
            *  
            *   Startup Battle
            *   Run Auto Battle
            * 
            * Test Conditions:
            *   Default condition is sufficient
            * 
            * Validation:
            *   Verify Battle Returned True
            *   Verify Doug is not able to attack 
            *   Verify HitStatusEnum is a Miss for character Doug
            *  
            */
            //Arrange
            // Set Character Conditions

            // Set Character Conditions
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 3;
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyMonsters = 6;

            // Add character Doug

            var CharacterPlayerDoug = new PlayerInfoModel(
                    new CharacterModel
                    {
                        Name = "Doug"
                    });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);

            // Add Character Jill
            var CharacterPlayerJill = new PlayerInfoModel(
                    new CharacterModel
                    {
                        Name = "Jill"
                    });

            // Add Character Bill
            var CharacterPlayerBill = new PlayerInfoModel(
                    new CharacterModel
                    {
                        Name = "Bill"
                    });

            // Set Monster Conditions
            // Auto Battle will add the monsters
            // Monsters always hit

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            //EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Miss, EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum);
        }
        #endregion Scenario2

        [Test]
        #region Scenario34
        public async Task HackathonScenario_Scenario_34_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      34
            *      
            * Description: 
            *      Move Based on Speed - A player is allowed to move a maximum distance units thats equal to their speed.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      TurnEngine.cs 
            *      - Updated Usage of MovePlayerOnMap Method
            *      MapModel.cs
            *       - isMoveValid - Method checks if a Move from one cell to other is valid
            *       - Above function is called in MovePlayerOnMap function, which should return false when the move is not true
            *      BattlePage.xaml.cs
            *      - Updated Usage of MovePlayerOnMap Method
            *      TurnEngineBase.cs
            *      - Updated Usage of MovePlayerOnMap Method
            *      TurnEngineBase.cs
            *      - Updated Usage of MovePlayerOnMap Method
            * 
            * Test Algrorithm:
            *      Added a Character with speed to Players List
            *      Move the charactger to a cell that is more than speed units away - The move should fail
            *      Move the Character to a cell that is speed units away - The move should be successful
            *     
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify if the Moves appropriately return true or false
            *  
            */

            //Arrange

            // Set Character Conditions

            var charmodel = new PlayerInfoModel(new CharacterModel
            {
                Speed = 2, 
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                ExperienceRemaining = 1,
                Name = "Speedster",
            });
            EngineViewModel.Engine.EngineSettings.PlayerList.Add(charmodel);
            EngineViewModel.Engine.EngineSettings.CurrentAttacker = charmodel;


            EngineViewModel.Engine.EngineSettings.MapModel.PopulateMapModel(EngineViewModel.Engine.EngineSettings.PlayerList);

            var mapModel = EngineViewModel.Engine.EngineSettings.MapModel;
            var playerLocation = mapModel.GetLocationForPlayer(charmodel);
            Assert.IsNotNull(playerLocation);
            var locations = mapModel.GetEmptyLocations();
            Assert.IsNotEmpty(locations);
            Assert.Greater(locations.Count, charmodel.Speed);

            ///Act and Verify
            ///
            //Check if moving player to a location that is at a distance more than the speed fails
            Assert.IsFalse(mapModel.MovePlayerOnMap(charmodel, playerLocation, locations[charmodel.Speed + 1]));
            //Check if moving player to a location within its speed-distance range is succeeds
            Assert.IsTrue(mapModel.MovePlayerOnMap(charmodel, playerLocation, locations[1]));

            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();
            
            Assert.AreEqual(result, true);
        }
        #endregion Scenario34

        #region Scenario3
        [Test]
        public async Task HackathonScenario_Scenario_3_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *   2
            *    
            * Description: 
            *   sleepless zombies in Seattle
            * 
            * Changes Required (Classes, Methods etc.) List Files, Methods, and Describe Changes: 
            *   No Code changes requied 
            * 
            * Test Algrorithm:
            *   Create Character named Doug along with 2 more characters
            *   Set Doug hit status to always miss
            *  
            *   Startup Battle
            *   Run Auto Battle
            * 
            * Test Conditions:
            *   Default condition is sufficient
            * 
            * Validation:
            *   Verify Battle Returned True
            *   Verify Doug is not able to attack 
            *   Verify HitStatusEnum is a Miss for character Doug
            *  
            */
            //Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowZombieMonsters = true;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ZombieOccuerencePercentage = 100;
            // Set Character Conditions

            // Set Character Conditions

            var CharacterPlayerJim = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 100,
                    Level = 1,
                    CurrentHealth = 100,
                    ExperienceTotal = 10,
                    ExperienceRemaining = 10,
                    Name = "Jim",
                    PrimaryHand = "Long Flame Sword"
                });
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerJim);

            var MonsterOne = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = -1, // Will go last...
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 0,
                    ExperienceRemaining = 0,
                    Name = "MonsterOne",
                });
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterOne);

            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = MonsterOne;

            // Set Monster Conditions
            // Auto Battle will add the monsters
            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.CriticalHit;

            //Act
            var result = EngineViewModel.Engine.Round.Turn.TurnAsAttack(CharacterPlayerJim, MonsterOne);


            //Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowZombieMonsters = false;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ZombieOccuerencePercentage = 0;
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, MonsterOne.Alive);
        }
        #endregion Scenario3
    }
}