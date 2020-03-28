using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MokomoGames
{
    public static class TransformExtensions
    {
        public static IEnumerable<GameObject> Childs(this Transform self)
        {
            return Enumerable
                .Range(0, self.childCount)
                .Select(x => self.GetChild(x).gameObject);
        }
    }
}