using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private static readonly WaitForSeconds WaitForOneSeconds = new WaitForSeconds(1);
    private readonly Dictionary<uint, Action> _specifiedSecondEventTables = new Dictionary<uint, Action>();
    private Coroutine _clockCoroutine;

    public Timer(uint second)
    {
        CurrentSecond = second;
    }

    private bool IsEnded => CurrentSecond <= 0;
    public uint CurrentSecond { get; private set; }

    public event Action OnEnded;
    public event Action OnStart;
    public event Action<uint> OnClocked;

    public void Play()
    {
        OnStart?.Invoke();
        _clockCoroutine = CoroutineHandler.Instance.StartCoroutine(ClockSequence());
    }

    public void Stop()
    {
        CoroutineHandler.Instance.StopCoroutine(_clockCoroutine);
    }

    public void AddSpecifiedSecondEvent(uint specifiedSecond, Action specifiedSecondEvent)
    {
        _specifiedSecondEventTables.Add(specifiedSecond, specifiedSecondEvent);
    }

    private IEnumerator ClockSequence()
    {
        while (true)
        {
            yield return WaitForOneSeconds;

            CurrentSecond--;
            OnClocked?.Invoke(CurrentSecond);

            _specifiedSecondEventTables.TryGetValue(CurrentSecond, out var specifiedEvent);
            specifiedEvent?.Invoke();

            if (IsEnded)
            {
                OnEnded?.Invoke();
                yield break;
            }
        }
    }
}