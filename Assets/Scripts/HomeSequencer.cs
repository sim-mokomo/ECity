using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MokomoGames
{
    public class HomeSequencer : MonoBehaviour, ISequencer
    {
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;
        [SerializeField] private HomeScreenController homeScreenController;

        public void Begin()
        {
            Display(true);
            homeScreenController.Begin();
        }

        public void Tick()
        {
            homeScreenController.Tick();
        }

        public void End()
        {
            homeScreenController.End();
            Display(false);
        }

        public void Display(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}