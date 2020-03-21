using System;

namespace MokomoGames
{
    public interface ISequencer
    {
        MasterSequencer.SequencerType Type { get; }
        event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;
        void Begin();
        void Tick();
        void End();
        void Display(bool show);
    }
}