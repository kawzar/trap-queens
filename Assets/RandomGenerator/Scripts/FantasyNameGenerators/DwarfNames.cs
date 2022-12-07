﻿using System.Collections.Generic;

namespace RandomGenerator.Scripts.FantasyNameGenerators
{
    public static class DwarfNames
    {
        public static readonly PartDefinition PrefixAdjective = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.Item,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "barbed", "battle", "beaten", "bitter", "black", "blazing", "blessed", "blood", "blunt", "bright", "broad", "broken",
                        "bronze", "dark", "dark", "deep", "dim", "dusk", "earth", "flint", "frozen", "golden", "grey", "grim", "grip", "grog",
                        "hard", "heavy", "iron", "light", "long", "oaken", "rune", "sapphire", "shadow", "shatter", "shattered", "silver",
                        "steel", "stone", "storm", "strong", "sunder", "thunder", "twilight"
                    }
                }
            }
        );

        public static readonly PartDefinition SuffixNoun = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.Item,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "arm", "armour", "axe", "barrel", "beard", "blood", "bottle", "boulder", "bow", "braid", "branch", "brow",
                        "buckle", "cask", "cave", "chain", "chest", "chin", "cloak", "coat", "coin", "crag", "dale", "foot", "forge", "fury",
                        "guard", "hammer", "hand", "heart", "helm", "hide", "hill", "jaw", "keg", "krag", "mantle", "maul", "rock", "shield",
                        "spine", "storm", "sword"
                    }
                }
            }
        );

        public static readonly PartDefinition PrefixNoun = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.Item,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "ash", "barrel", "battle", "beast", "blade", "blood", "bone", "bottle", "boulder", "brick", "chain", "crag",
                        "dragon", "dusk", "earth", "fire", "flint", "frost", "giant", "goblin", "heart", "jade", "kobold", "metal", "orc",
                        "rock", "rune", "shadow", "shield", "stone", "sword", "troll", "wyvern"
                    }
                }
            }
        );

        public static readonly PartDefinition SuffixAdjective = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.MarkovOrItem,
            maxLength: 12,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "bane", "basher", "beater", "bender", "biter", "blood", "born", "braid", "brand", "breaker", "brewer", "bringer",
                        "buster", "cleaver", "crusher", "cutter", "delver", "digger", "eater", "flayer", "forged", "forger", "hunter",
                        "maker", "marked", "master", "ravager", "ripper", "seeker", "shaper", "smasher", "smith", "ward", "worker"
                    }
                }
            }
        );
    }
}