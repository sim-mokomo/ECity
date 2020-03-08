using MokomoGames.Protobuf;

namespace MokomoGames
{
    public static class SoulTypeExtensions
    {
        public static bool IsMaterial(this SoulType self)
        {
            return self == SoulType.Evolution ||
                   self == SoulType.Sale ||
                   self == SoulType.ReinforcedSynthesis;
        }
    }
}