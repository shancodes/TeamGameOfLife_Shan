using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.GameRules;
using Game.Models;
using Game.ViewModels;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// AutoBattle Engine
    /// 
    /// Runs the engine simulation with no user interaction
    /// 
    /// </summary>
    public class AutoBattleEngine : AutoBattleEngineBase, IAutoBattleInterface
    {
        #region Algrorithm
        // Prepare for Battle
        // Pick 6 Characters
        // Initialize the Battle
        // Start a Round

        // Fight Loop
        // Loop in the round each turn
        // If Round is over, Start New Round
        // Check end state of round/game

        // Wrap up
        // Get Score
        // Save Score
        // Output Score
        #endregion Algrorithm

        public new IBattleEngineInterface Battle
        {
            get
            {
                if (base.Battle == null)
                {
                    base.Battle = new BattleEngine();
                }
                return base.Battle;
            }
            set { base.Battle = Battle; }
        }

        /// <summary>
        /// Run Auto Battle
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<bool> RunAutoBattle()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RoundEnum RoundCondition;

            Debug.WriteLine("Auto Battle Starting");

            // Auto Battle, does all the steps that a human would do.

            // Prepare for Battle

            _ = CreateCharacterParty();

            // Start Battle in AutoBattle mode
            _ = Battle.StartBattle(true);

            // Fight Loop. Continue until Game is Over...
            do
            {
                // Check for excessive duration.
                if (DetectInfinateLoop())
                {
                    Debug.WriteLine("Aborting, More than Max Rounds");
                    _ = Battle.EndBattle();
                    return false;
                }

                Debug.WriteLine("Next Turn");

                // Do the turn...
                // If the round is over start a new one...
                RoundCondition = Battle.Round.RoundNextTurn();

                if (RoundCondition == RoundEnum.NewRound)
                {
                    _ = Battle.Round.NewRound();
                    Debug.WriteLine("New Round");
                }

            } while (RoundCondition != RoundEnum.GameOver);

            Debug.WriteLine("Game Over");

            // Wrap up
            _ = Battle.EndBattle();

            return true;
        }

        /// <summary>
        /// Check if the Engine is not ending
        /// 
        /// Too many Rounds
        /// Too many Turns in a round
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DetectInfinateLoop()
        {
            if (Battle.EngineSettings.BattleScore.RoundCount > Battle.EngineSettings.MaxRoundCount)
            {
                return true;
            }
            return Battle.EngineSettings.BattleScore.TurnCount > Battle.EngineSettings.MaxTurnCount;
           
        }

        /// <summary>
        /// Create Characters for Party
        /// </summary>
        public override bool CreateCharacterParty()
        {
            // Picks 6 Characters

            // To use your own characters, populate the List before calling RunAutoBattle

            var CharaceterModlList = CharacterIndexViewModel.Instance.Dataset;

            if (CharaceterModlList == null || CharaceterModlList.Count == 0) {
                return false;
            }

            int dataSetCount = CharaceterModlList.Count;
            int cListCount = Battle.EngineSettings.CharacterList.Count();

            return addCharacterToBattle(CharaceterModlList, cListCount);
        }

        public bool addCharacterToBattle(ObservableCollection<CharacterModel> characterList, int cListCount) {
            int i = 0;

            while (cListCount < Battle.EngineSettings.MaxNumberPartyCharacters)
            {

                var data = characterList[i];
                data.CurrentHealth = data.GetMaxHealthTotal;
                Battle.PopulateCharacterList(data);
                i++;
                cListCount++;
            }

            return true;
        }

    }
}