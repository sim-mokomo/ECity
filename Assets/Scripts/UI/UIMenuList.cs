using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuList : MonoBehaviour,IOpenable
{
    public float endvalue;
    public float duration;
    public float value;
    public float d;
    private bool isOpening;
    [SerializeField] private RectTransform _rectTransform;

    public bool IsOpening => isOpening;
    public event Action OnOpen;
    public event Action OnClose;

    protected virtual void Awake()
    {
        OnOpen += () =>  _rectTransform.DOLocalMoveX(endvalue, duration, snapping: true);
        OnClose += () => _rectTransform.DOLocalMoveX(value, d, snapping: true);
    }

    public virtual void Open()
    {
        isOpening = true;
        OnOpen?.Invoke();
    }

    public virtual void Close()
    {
        OnClose?.Invoke();
        isOpening = false;
    }

    public virtual void Tick()
    {
        
    }
}
