using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MokomoGames
{
    public class LoadingSequencer : MonoBehaviour, ISequencer
    {
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Loading;
        public event Action<MasterSequencer.SequencerType> OnLeave;
        private event Func<bool> leaveCondition;
        public MasterSequencer.SequencerType DistSequencer { get; private set; }

        public void Begin()
        {
            Display(true);
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            while (!leaveCondition())
            {
                yield return null;
            }

            OnLeave?.Invoke(DistSequencer);
        }

        public void Tick()
        {
        }

        public void End()
        {
            Display(false);
        }

        public void Display(bool show)
        {
            gameObject.SetActive(show);
        }

        public void SetConfiguraiton(Func<bool> leaveCondition, MasterSequencer.SequencerType distType)
        {
            this.leaveCondition = leaveCondition;
            this.DistSequencer = distType;
        }
    }
}