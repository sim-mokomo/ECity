using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MokomoGames
{
    public class TitleSequencer : MonoBehaviour,ISequencer
    {
        [SerializeField] private TextMeshProUGUI loginIdText;
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Title;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;

        public void Begin()
        {
            Display(true);
            var userData = MainGameController.UserData;
            loginIdText.text = $"ID:{userData.PlayFabId}";
        }

        public void Tick()
        {
            var inputType = CommonInput.GetTouch();
            if (inputType == TouchType.Began)
            {
                OnLeave?.Invoke(MasterSequencer.SequencerType.Home,false,null);
            }
        }

        public void End()
        {
            Display(false);
        }

        public void Display(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}
