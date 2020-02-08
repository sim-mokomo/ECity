using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MokomoGames
{
    public class MasterSequencer : MonoBehaviour
    {
        public enum SequencerType
        {
            Loading,
            Title,
            Home,
        }

        private List<ISequencer> sequencers;
        private ISequencer currentSequencer;
        private LoadingSequencer loadingSequencer;

        private void Awake()
        {
            sequencers = FindObjectsOfType<MonoBehaviour>().OfType<ISequencer>().ToList();
            loadingSequencer = sequencers.FirstOrDefault(x => x.Type == SequencerType.Loading) as LoadingSequencer;
        }

        public void Begin(SequencerType beginSequencerType)
        {
            ChangeSequence(beginSequencerType);
        }

        public void Tick()
        {
            currentSequencer.Tick();
        }

        public void ChangeSequence(SequencerType distType)
        {
            currentSequencer?.End();
            var distSequencer = sequencers.FirstOrDefault(x => x.Type == distType);
            currentSequencer = distSequencer;
            currentSequencer.OnLeave -= CurrentSequencerOnLeave;
            currentSequencer.OnLeave += CurrentSequencerOnLeave;
            currentSequencer.Begin();
        }
        private void CurrentSequencerOnLeave(SequencerType distType,bool withLoad,Func<bool> loadLeaveCondition = null)
        {
            if (withLoad)
            {
                ChangeSequenceWithLoading(loadLeaveCondition,distType);
            }
            else
            {
                ChangeSequence(distType);
            }
        }
        
        public void ChangeSequenceWithLoading(Func<bool> condition, SequencerType distType)
        {
            loadingSequencer.SetConfiguraiton(condition, distType);
            ChangeSequence(SequencerType.Loading);
        }

        public void AllDisplay(bool show)
        {
            foreach (var sequencer in sequencers)
            {
                sequencer.Display(show);
            }
        }
    }
}