using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace MokomoGames
{
    public class PlayerSaveData
    {
        [SerializeField] private uint stamina;

        public uint Stamina => stamina;

        public PlayerSaveData(uint stamina)
        {
            this.stamina = stamina;
        }

        public Dictionary<string, string> ToSaveDic()
        {
            var saveDic = new Dictionary<string,string>();
            saveDic.Add("stamina",Stamina.ToString(CultureInfo.InvariantCulture));
            return saveDic;
        }

        public override bool Equals(object obj)
        {
            var other = obj as PlayerSaveData;
            return this.Stamina == other.Stamina;
        }
    }
}
