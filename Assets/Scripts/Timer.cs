using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private uint currentSecond;
    private Coroutine _clockCoroutine;
    private readonly Dictionary<uint, Action> _specifiedSecondEventTables = new Dictionary<uint, Action>();
    private static readonly WaitForSeconds WaitForOneSeconds = new WaitForSeconds(1);

    private bool IsEnded => currentSecond <= 0;
    public uint CurrentSecond => currentSecond;

    public event Action OnEnded;
    public event Action OnStart;
    public event Action<uint> OnClocked;

    public Timer(uint second)
    {
        currentSecond = second;
    }

    public void Play()
    {
        OnStart?.Invoke();
        _clockCoroutine = CoroutineHandler.Instance.StartCoroutine(ClockSequence());
    }

    public void Stop()
    {
        CoroutineHandler.Instance.StopCoroutine(_clockCoroutine);
    }

    public void AddSpecifiedSecondEvent(uint specifiedSecond,Action specifiedSecondEvent)
    {
        _specifiedSecondEventTables.Add(specifiedSecond,specifiedSecondEvent);
    }

    IEnumerator ClockSequence()
    {
        while (true)
        {
            yield return WaitForOneSeconds;

            currentSecond--;
            OnClocked?.Invoke(currentSecond);

            _specifiedSecondEventTables.TryGetValue(currentSecond, out var specifiedEvent);
            specifiedEvent?.Invoke();

            if (IsEnded)
            {
                OnEnded?.Invoke();
                yield break;
            }
        }
    }
}