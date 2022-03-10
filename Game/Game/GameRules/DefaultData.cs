using System.Collections.Generic;

using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Blazing Hammer",
                    Description = "Powerful Hammer",
                    ImageURI = "blazing_hammer.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

               new ItemModel {
                    Name = "Burning Polyarm",
                    Description ="A Burning Polyarm",
                    ImageURI = "burning_polyarm.png",
                    Range = 2,
                    Damage = 8,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Fast Dagger",
                    Description = "Powerful Weapon",
                    ImageURI = "fast_dagger.png",
                    Range = 2,
                    Damage = 6,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Fire Ring",
                    Description = "Ring made of fire",
                    ImageURI = "fire_ring.png",
                    Range = 2,
                    Damage = 12,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Mystic Staff",
                    Description = "Powerful Weapon",
                    ImageURI = "mystic_staff.png",
                    Range = 2,
                    Damage = 4,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},


                new ItemModel {
                    Name = "Long Flame Sword",
                    Description = "Sword that is long and made of fire",
                    ImageURI = "long_flame_sword.png",
                    Range = 2,
                    Damage = 6,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth},

                
                new ItemModel {
                    Name = "Fiery Katana",
                    Description = "Katana made of fire",
                    ImageURI = "fiery_katana.png",
                    Range = 2,
                    Damage = 6,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Infinity Tiara",
                    Description = "Powerful tiara",
                    ImageURI = "infinity_tiara.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Iron Shield",
                    Description = "Shield made of iron",
                    ImageURI = "iron_shield.png",
                    Range = 2,
                    Damage = 6,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Red Necklace",
                    Description = "Fast Red Necklace",
                    ImageURI = "red_necklace.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.MaxHealth},

                new ItemModel {
                    Name = "Swift boots",
                    Description = "Fast running boots",
                    ImageURI = "swift_boots.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed},
/*

                new ItemModel {
                    Name = "Strong Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "shield1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Fancy Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "shield2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Health Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "shield3.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth},

                new ItemModel {
                    Name = "Lucky Shield",
                    Description = "Do you feel lucky punk?",
                    ImageURI = "shield4.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "hat1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Horned Hat",
                    Description = "Where's the Rabbit?",
                    ImageURI = "hat2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Fast Necklass",
                    Description = "And Tasty",
                    ImageURI = "neck1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Feel the Power",
                    Description = "Love this one",
                    ImageURI = "neck2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Horned Hat",
                    Description = "Where's the Rabbit?",
                    ImageURI = "hat2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Ring of Power",
                    Description = "The wearer has all the power",
                    ImageURI = "ring1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Strong Ring",
                    Description = "Watch out",
                    ImageURI = "ring2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Warm Shoes",
                    Description = "Strong Shoes",
                    ImageURI = "feet1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Cute Shoes",
                    Description = "really fast",
                    ImageURI = "feet2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed},*/
            };

            return datalist;
        }

        /// <summary>
        /// Load Example Scores
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
            var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklace);
            var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
            var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
            var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
            var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
            var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);

            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Fire Princess",
                    Description = "Fire Princess",
                    Level = 1,
                    MaxHealth = 5,
                    Speed = 2,
                    ImageURI = "fire_princess.png",
                    GIFURI = "fire_princess.gif",
                    Head = HeadString,
                    Necklass = NecklassString,
                },

                new CharacterModel {
                    Name = "Fire Wielder",
                    Description = "Fire Wielder",
                    Level = 1,
                    MaxHealth = 5,
                    Speed = 3,
                    ImageURI = "fire_wielder.png",
                    GIFURI = "fire_wielder.gif",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                },

                new CharacterModel {
                    Name = "Night Walker",
                    Description = "Night Walker",
                    Level = 1,
                    MaxHealth = 8,
                    Speed = 1,
                    ImageURI = "night_walker.png",
                    GIFURI = "night_walker.gif",
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Sharp Shooter",
                    Description = "Sharp Shooter",
                    Level = 4,
                    MaxHealth = 38,
                    Speed = 4,
                    ImageURI = "sharpshooter.png",
                    GIFURI = "sharpshooter.gif",
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                },

                new CharacterModel {
                    Name = "Swiftblade",
                    Description = "Swiftblade",
                    Level = 5,
                    MaxHealth = 43,
                    Speed = 3,
                    ImageURI = "swiftblade.png",
                    GIFURI = "swiftblade.gif",
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Wizard",
                    Description = "Wizard",
                    Level = 5,
                    MaxHealth = 43,
                    Speed = 2,
                    ImageURI = "wizard.png",
                    GIFURI = "wizard.gif",
                    Feet = FeetString,
                    PrimaryHand = PrimaryHandString,
                },

                new CharacterModel {
                    Name = "Black Knight",
                    Description = "Black Knight",
                    Level = 5,
                    MaxHealth = 43,
                    Speed = 4,
                    ImageURI = "black_knight.png",
                    GIFURI = "black_knight.gif",
                    Feet = FeetString,
                    Head = HeadString,
                    Necklass = NecklassString,
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Ice Thief",
                    Description = "Big and Ugly",
                    ImageURI = "ice_thief.png",
                    GIFURI = "ice_thief_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },
                new MonsterModel {
                    Name = "Ice Bear",
                    Description = "Large Monster Bear",
                    ImageURI = "ice_bear.png",
                    GIFURI = "ice_bear_gif.gif",
                    Difficulty = DifficultyEnum.Difficult,
                },
                new MonsterModel {
                    Name = "Ice Jester",
                    Description = "and fast",
                    ImageURI = "ice_jester.png",
                    GIFURI = "ice_jester_gif.gif",
                    Difficulty = DifficultyEnum.Hard,
                },
                new MonsterModel {
                    Name = "Ice Princess",
                    Description = "Monster Princess",
                    ImageURI = "ice_princess.png",
                    GIFURI = "ice_princess_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },
                new MonsterModel {
                    Name = "Ice Queen",
                    Description = "Powerful Monster Queen",
                    ImageURI = "ice_queen.png",
                    GIFURI = "ice_queen_gif.gif",
                    Difficulty = DifficultyEnum.Difficult,
                },
                new MonsterModel {
                    Name = "Ice Knight",
                    Description = "Powerful Monster Black Knight",
                    ImageURI = "ice_knight.png",
                    GIFURI = "ice_knight_gif.gif",
                     Difficulty = DifficultyEnum.Hard,
                },
                 new MonsterModel {
                    Name = "Ice Slime",
                    Description = "Cruel Monster Slime",
                    ImageURI = "ice_slime.png",
                    GIFURI = "ice_slime_gif.gif",
                    Difficulty = DifficultyEnum.Hard,
                },
                new MonsterModel {
                    Name = "Ice Wolf",
                    Description = "Fast Monster Wolf",
                    ImageURI = "ice_wolf.png",
                    GIFURI = "ice_wolf_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                }
            };

            return datalist;
        }

            /// <summary>
            /// Load Characters
            /// </summary>
            /// <param name="temp"></param>
            /// <returns></returns>
        public static List<List<MonsterModel>> LoadDataForDifficulties()
        {
            var joeList = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Ice Thief",
                    Description = "Big and Ugly",
                    ImageURI = "ice_thief.png",
                    GIFURI = "ice_thief_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                },

                new MonsterModel {
                    Name = "Ice Bear",
                    Description = "Large Monster Bear",
                    ImageURI = "ice_bear.png",
                    GIFURI = "ice_bear_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                },

                new MonsterModel {
                    Name = "Ice Jester",
                    Description = "and fast",
                    ImageURI = "ice_jester.png",
                    GIFURI = "ice_jester_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },

                new MonsterModel {
                    Name = "Ice Princess",
                    Description = "Monster Princess",
                    ImageURI = "ice_princess.png",
                    GIFURI = "ice_princess_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },

                new MonsterModel {
                    Name = "Ice Queen",
                    Description = "Powerful Monster Queen",
                    ImageURI = "ice_queen.png",
                    GIFURI = "ice_queen_gif.gif",
                    Difficulty = DifficultyEnum.Hard,
                },

                new MonsterModel {
                    Name = "Ice Knight",
                    Description = "Powerful Monster Black Knight",
                    ImageURI = "ice_knight.png",
                    GIFURI = "ice_knight_gif.gif",
                     Difficulty = DifficultyEnum.Hard,
                },

                 new MonsterModel {
                    Name = "Ice Slime",
                    Description = "Cruel Monster Slime",
                    ImageURI = "ice_slime.png",
                    GIFURI = "ice_slime_gif.gif",
                    Difficulty = DifficultyEnum.Hard,
                },

                new MonsterModel {
                    Name = "Ice Wolf",
                    Description = "Fast Monster Wolf",
                    ImageURI = "ice_wolf.png",
                     GIFURI = "ice_wolf_gif.gif",
                    Difficulty = DifficultyEnum.Difficult,
                },
            };

            var proList = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Ice Thief",
                    Description = "Big and Ugly",
                    ImageURI = "ice_thief.png",
                    GIFURI = "ice_thief_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },

                new MonsterModel {
                    Name = "Ice Bear",
                    Description = "Large Monster Bear",
                    ImageURI = "ice_bear.png",
                    GIFURI = "ice_bear_gif.gif",
                    Difficulty = DifficultyEnum.Hard,
                },

                new MonsterModel {
                    Name = "Ice Jester",
                    Description = "and fast",
                    ImageURI = "ice_jester.png",
                    GIFURI = "ice_jester_gif.gif",
                    Difficulty = DifficultyEnum.Hard,
                },

                new MonsterModel {
                    Name = "Ice Princess",
                    Description = "Monster Princess",
                    ImageURI = "ice_princess.png",
                    GIFURI = "ice_princess_gif.gif",
                    Difficulty = DifficultyEnum.Difficult,
                },

                new MonsterModel {
                    Name = "Ice Queen",
                    Description = "Powerful Monster Queen",
                    ImageURI = "ice_queen.png",
                    GIFURI = "ice_queen_gif.gif",
                    Difficulty = DifficultyEnum.Difficult,
                },

                new MonsterModel {
                    Name = "Ice Knight",
                    Description = "Powerful Monster Black Knight",
                    ImageURI = "ice_knight.png",
                    GIFURI = "ice_knight_gif.gif",
                     Difficulty = DifficultyEnum.Difficult,
                },

                 new MonsterModel {
                    Name = "Ice Slime",
                    Description = "Cruel Monster Slime",
                    ImageURI = "ice_slime.png",
                    GIFURI = "ice_slime_gif.gif",
                    Difficulty = DifficultyEnum.Impossible,
                },

                new MonsterModel {
                    Name = "Ice Wolf",
                    Description = "Fast Monster Wolf",
                    ImageURI = "ice_wolf.png",
                     GIFURI = "ice_wolf_gif.gif",
                    Difficulty = DifficultyEnum.Impossible,
                },
            };

            var noobList = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Ice Thief",
                    Description = "Big and Ugly",
                    ImageURI = "ice_thief.png",
                    GIFURI = "ice_thief_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                },

                new MonsterModel {
                    Name = "Ice Bear",
                    Description = "Large Monster Bear",
                    ImageURI = "ice_bear.png",
                    GIFURI = "ice_bear_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                },

                new MonsterModel {
                    Name = "Ice Jester",
                    Description = "and fast",
                    ImageURI = "ice_jester.png",
                    GIFURI = "ice_jester_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                },

                new MonsterModel {
                    Name = "Ice Princess",
                    Description = "Monster Princess",
                    ImageURI = "ice_princess.png",
                    GIFURI = "ice_princess_gif.gif",
                    Difficulty = DifficultyEnum.Easy,
                },

                new MonsterModel {
                    Name = "Ice Queen",
                    Description = "Powerful Monster Queen",
                    ImageURI = "ice_queen.png",
                    GIFURI = "ice_queen_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },

                new MonsterModel {
                    Name = "Ice Knight",
                    Description = "Powerful Monster Black Knight",
                    ImageURI = "ice_knight.png",
                    GIFURI = "ice_knight_gif.gif",
                     Difficulty = DifficultyEnum.Average,
                },

                 new MonsterModel {
                    Name = "Ice Slime",
                    Description = "Cruel Monster Slime",
                    ImageURI = "ice_slime.png",
                    GIFURI = "ice_slime_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },

                new MonsterModel {
                    Name = "Ice Wolf",
                    Description = "Fast Monster Wolf",
                    ImageURI = "ice_wolf.png",
                     GIFURI = "ice_wolf_gif.gif",
                    Difficulty = DifficultyEnum.Average,
                },
            };

            var datalist = new List<List<MonsterModel>>();
            datalist.Add(noobList);
            datalist.Add(joeList);
            datalist.Add(proList);
            return datalist;
        }
    }
}