using System;
using UnityEngine;

namespace MokomoGames
{
    [Serializable]
    public class Trigger : MonoBehaviour
    {
        public event Action OnDetect;

        protected void Detect()
        {
            OnDetect?.Invoke();
        }
    }
}