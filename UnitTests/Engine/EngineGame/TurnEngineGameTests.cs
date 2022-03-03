﻿
using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.Engine.EngineBase;
using Game.Helpers;
using System.Collections.Generic;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class TurnEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            Engine.EngineSettings.BattleScore.AutoBattle = false;
            Engine.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Unknown;
            //Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region MoveAsTurn
        [Test]
        public void RoundEngine_MoveAsTurn_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundEngine_MoveAsTurn_Valid_Monster_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion MoveAsTurn

        #region ApplyDamage
        [Test]
        public void RoundEngine_ApplyDamage_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.ApplyDamage(new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion ApplyDamage

        #region Attack
        [Test]
        public void RoundEngine_Attack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.Attack(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion Attack

        #region AttackChoice
        [Test]
        public void RoundEngine_AttackChoice_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.AttackChoice(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion AttackChoice

        #region SelectCharacterToAttack
        [Test]
        public void RoundEngine_SelectCharacterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SelectCharacterToAttack

        #region UseAbility
        [Test]
        public void RoundEngine_UseAbility_Valid_Default_Should_Pass()
        {
            // Arrange 
            

            // Act
            var result = Engine.Round.Turn.UseAbility(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion UseAbility

        #region BattleSettingsOverrideHitStatusEnum
        [Test]
        public void RoundEngine_BattleSettingsOverrideHitStatusEnum_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }
        #endregion BattleSettingsOverrideHitStatusEnum

        #region BattleSettingsOverride
        [Test]
        public void RoundEngine_BattleSettingsOverride_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverride(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }
        #endregion BattleSettingsOverride

        #region CalculateExperience
        [Test]
        public void RoundEngine_CalculateExperience_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.CalculateExperience(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion CalculateExperience

        #region CalculateAttackStatus
        [Test]
        public void RoundEngine_CalculateAttackStatus_Valid_Default_Should_Pass()
        {
            // Arrange
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(11);

            // Act
            var result = Engine.Round.Turn.CalculateAttackStatus(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }
        #endregion CalculateAttackStatus

        #region RemoveIfDead
        [Test]
        public void RoundEngine_RemoveIfDead_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.RemoveIfDead(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion RemoveIfDead

        #region ChooseToUseAbility
        [Test]
        public void RoundEngine_ChooseToUseAbility_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion ChooseToUseAbility

        #region SelectMonsterToAttack
        [Test]
        public void RoundEngine_SelectMonsterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SelectMonsterToAttack

        #region DetermineActionChoice
        [Test]
        public void RoundEngine_DetermineActionChoice_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Move, result);
        }
        #endregion DetermineActionChoice

        #region TurnAsAttack
        [Test]
        public void RoundEngine_TurnAsAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TurnAsAttack

        #region TargetDied
        [Test]
        public void RoundEngine_TargetDied_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TargetDied(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TargetDied

        #region TakeTurn
        [Test]
        public void RoundEngine_TakeTurn_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TakeTurn(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundEngine_TakeTurn_Valid_Unknown_Action_Should_Pass()
        {
            // Arrange 
            var previousAction = Engine.EngineSettings.CurrentAction;
            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;

            PlayerInfoModel character = new PlayerInfoModel();
            character.PlayerType = PlayerTypeEnum.Character;

            PlayerInfoModel monster = new PlayerInfoModel();
            monster.PlayerType = PlayerTypeEnum.Monster;

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Act
            var result = Engine.Round.Turn.TakeTurn(character);

            // Reset
            Engine.EngineSettings.CurrentAction = previousAction;
            Engine.EngineSettings.PlayerList.Clear();
            Engine.EngineSettings.MapModel.ClearMapGrid();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundEngine_TakeTurn_Valid_Character_Ability_Action_Should_Pass()
        {
            // Arrange 
            var previousAction = Engine.EngineSettings.CurrentAction;
            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;

            PlayerInfoModel character = new PlayerInfoModel();
            character.PlayerType = PlayerTypeEnum.Character;

            PlayerInfoModel monster = new PlayerInfoModel();
            monster.PlayerType = PlayerTypeEnum.Monster;

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);
            Engine.EngineSettings.CurrentAction = ActionEnum.Ability;

            // Act
            var result = Engine.Round.Turn.TakeTurn(character);

            // Reset
            Engine.EngineSettings.CurrentAction = previousAction;
            Engine.EngineSettings.PlayerList.Clear();
            Engine.EngineSettings.MapModel.ClearMapGrid();
            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion TakeTurn

        #region RollToHitTarget
        [Test]
        public void RoundEngine_RollToHitTarget_Valid_Default_Should_Pass()
        {
            // Arrange 
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(20);
            bool previousAllowCriticalHit = Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit;
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(1,1);

            // Reset
            _ = DiceHelper.DisableForcedRolls();
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = previousAllowCriticalHit;

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }
        #endregion RollToHitTarget

        #region GetRandomMonsterItemDrops
        [Test]
        public void RoundEngine_GetRandomMonsterItemDrops_Valid_Default_Should_Pass()
        {
            // Arrange 
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);


            // Act
            var result = Engine.Round.Turn.GetRandomMonsterItemDrops(1);

            // Reset
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(0, result.Count);
        }
        #endregion GetRandomMonsterItemDrops

        #region DetermineCriticalMissProblem
        [Test]
        public void RoundEngine_DetermineCriticalMissProblem_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.DetermineCriticalMissProblem(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion DetermineCriticalMissProblem

        #region DropItems
        [Test]
        public void RoundEngine_DropItems_Valid_Default_Should_Pass()
        {
            // Arrange 
            PlayerInfoModel player = new PlayerInfoModel();

            // Act
            var result = Engine.Round.Turn.DropItems(player);

            // Reset

            // Assert
            Assert.IsTrue(result >= 0);
        }
        #endregion DropItems

        #region DetermineActionChoice
        [Test]
        public void RoundEngine_DetermineActionChoice_Valid_In_Range_Attack_Should_Pass()
        {
            // Arrange 
            PlayerInfoModel character = new PlayerInfoModel();
            character.PlayerType = PlayerTypeEnum.Character;

            PlayerInfoModel monster = new PlayerInfoModel();
            monster.Range = 999;
            monster.PlayerType = PlayerTypeEnum.Monster;

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAttacker = monster;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(monster);

            // Reset
            Engine.EngineSettings.PlayerList.Clear();
            Engine.EngineSettings.MapModel.ClearMapGrid();
            Engine.EngineSettings.CurrentAttacker = null;

            // Assert
            Assert.AreEqual(ActionEnum.Attack, result);
        }
        #endregion DetermineActionChoice

        #region SelectCharacterToAttack
        [Test]
        public void RoundEngine_SelectCharacterToAttack_Valid_Empty_PlayerList_Should_Pass()
        {
            // Arrange 
            Engine.EngineSettings.PlayerList = null;

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset
            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SelectCharacterToAttack

        #region SelectMonsterToAttack
        [Test]
        public void RoundEngine_SelectMonsterToAttack_Valid_Empty_PlayerList_Should_Pass()
        {
            // Arrange 
            Engine.EngineSettings.PlayerList = null;

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset
            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SelectMonsterToAttack

        #region TurnAsAttack
        [Test]
        public void RoundEngine_TurnAsAttack_Valid_Null_Attacker_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(null, new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundEngine_TurnAsAttack_Valid_Attacker_Doug_Miss_Should_Pass()
        {
            // Arrange 
            PlayerInfoModel attacker = new PlayerInfoModel();
            attacker.Name = "Doug";
            var currentType = Engine.EngineSettings.BattleMessagesModel.PlayerType;
            Engine.EngineSettings.BattleMessagesModel.PlayerType = PlayerTypeEnum.Character;

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(attacker, new PlayerInfoModel());

            // Reset
            Engine.EngineSettings.BattleMessagesModel.PlayerType = currentType;

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, Engine.EngineSettings.BattleMessagesModel.HitStatus);
        }

        [Test]
        public void RoundEngine_TurnAsAttack_Valid_Attacker_Defender_Critical_Miss_Should_Pass()
        {
            // Arrange 
            var previousHitEnum = Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum;
            Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.CriticalMiss;

            // Act
           _ = Engine.Round.Turn.TurnAsAttack(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset
            Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = previousHitEnum;

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, Engine.EngineSettings.BattleMessagesModel.HitStatus);
        }


        #endregion TurnAsAttack

        #region RollToHitTarget
        [Test]
        public void RoundEngine_RollToHitTarget_Valid_Critical_Miss_Should_Pass()
        {
            // Arrange 
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);
            var previousHitEnum = Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss;
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = true;

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(5, 5);

            // Reset
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = previousHitEnum;
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
        }
        #endregion RollToHitTarget

        #region TargetDied
        [Test]
        public void RoundEngine_TargetDied_Valid_Zombie_Name_Should_Pass()
        {
            // Arrange 
            PlayerInfoModel monster = new PlayerInfoModel();
            monster.PlayerType = PlayerTypeEnum.Monster;
            monster.Name = "Zombie Monster";

            Engine.EngineSettings.BattleSettingsModel.AllowZombieMonsters = true;
            Engine.EngineSettings.BattleSettingsModel.ZombieOccuerencePercentage = 100;
            Engine.EngineSettings.CurrentDefender = monster;

            // Act
            var result = Engine.Round.Turn.TargetDied(monster);

            // Reset
            Engine.EngineSettings.BattleSettingsModel.AllowZombieMonsters = false;
            Engine.EngineSettings.BattleSettingsModel.ZombieOccuerencePercentage = 0;
            Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual("Zombie Monster", monster.Name);
        }
        #endregion TargetDied


        #region ChooseToUseAbility
        [Test]
        public void RoundEngine_ChooseToUseAbility_Valid_No_Ability_Should_Pass()
        {
            // Arrange 
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);
            PlayerInfoModel player = new PlayerInfoModel();

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(player);

            // Reset
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundEngine_ChooseToUseAbility_Valid_Use_Healing_Ability_Should_Pass()
        {
            // Arrange
            PlayerInfoModel player = new PlayerInfoModel();
            player.MaxHealth = 100;
            player.CurrentHealth = 20;
            player.AbilityTracker.Add(AbilityEnum.Heal, 5);

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(player);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(ActionEnum.Ability, Engine.EngineSettings.CurrentAction);
        }

        [Test]
        public void RoundEngine_ChooseToUseAbility_Valid_Use_Ability_Should_Pass()
        {
            // Arrange 
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);
            PlayerInfoModel player = new PlayerInfoModel();
            player.AbilityTracker.Add(AbilityEnum.Toughness, 5);

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(player);

            // Reset
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(ActionEnum.Ability, Engine.EngineSettings.CurrentAction);
        }
        #endregion ChooseToUseAbility
    }
}