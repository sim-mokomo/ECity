using System;
using System.Collections;
using UnityEngine;

namespace MokomoGames
{
    public class LoadingSequencer : MonoBehaviour, ISequencer
    {
        public MasterSequencer.SequencerType DistSequencer { get; private set; }
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Loading;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;

        public void Begin()
        {
            Display(true);
            StartCoroutine(Wait());
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

        private event Func<bool> leaveCondition;

        private IEnumerator Wait()
        {
            while (!leaveCondition()) yield return null;

            OnLeave?.Invoke(DistSequencer, false, null);
        }

        public void SetConfiguraiton(Func<bool> leaveCondition, MasterSequencer.SequencerType distType)
        {
            this.leaveCondition = leaveCondition;
            DistSequencer = distType;
        }
    }
}