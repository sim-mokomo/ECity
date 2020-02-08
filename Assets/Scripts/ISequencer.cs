using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using UnityEngine;

namespace MokomoGames
{
    public interface ISequencer
    {
        MasterSequencer.SequencerType Type { get; }
        event Action<MasterSequencer.SequencerType> OnLeave;
        void Begin();
        void Tick();
        void End();
        void Display(bool show);
    }
}
