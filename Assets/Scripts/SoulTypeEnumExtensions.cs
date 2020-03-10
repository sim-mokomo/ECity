using System;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public static class SoulTypeEnumExtensions
    {
        public static string GetName(this SoulType self)
        {
            switch (self)
            {
                case SoulType.Art:
                    return "アート系";
                case SoulType.Underground:
                    return "アングラ系";
                case SoulType.Cure:
                    return "癒し系";
                case SoulType.Toughness:
                    return "体力系";
                case SoulType.Transcendence:
                    return "超越系";
                case SoulType.Balance:
                    return "バランス系";
                case SoulType.ReinforcedSynthesis:
                    return "強化合成";
                case SoulType.Evolution:
                    return "進化";
                case SoulType.Sale:
                    return "売却";
                case SoulType.Unknown:
                default:
                    return "???";
            }
        }
    }
}