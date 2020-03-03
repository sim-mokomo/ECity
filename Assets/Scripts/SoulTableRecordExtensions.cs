using System.Collections;
using System.Collections.Generic;
using MokomoGames.Protobuf;
using UnityEngine;

public static class SoulTableRecordExtensions
{
    public static bool IsMaterial(this SoulTableRecord self)
    {
        return self.SoulType == SoulType.Evolution ||
               self.SoulType == SoulType.Sale ||
               self.SoulType == SoulType.ReinforcedSynthesis;
    }
}
