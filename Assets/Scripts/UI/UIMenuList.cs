using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuList : MonoBehaviour,IOpenable
{
    [SerializeField] private float moveDistXWhenOpen;
    [SerializeField] private float moveDistXWhenClose;
    [SerializeField] private float moveDurationWhenOpen;
    [SerializeField] private float moveDurationWhenClose;
    [SerializeField] private RectTransform moveRectTransform;
    private TweenerCore<Vector3, Vector3, VectorOptions> openTweenerCore;
    private TweenerCore<Vector3, Vector3, VectorOptions> closeTweenerCore;

    public float MoveDurationWhenOpen => moveDurationWhenOpen;
    public bool IsOpening => openTweenerCore != null || closeTweenerCore == null || closeTweenerCore.IsActive();
    public event Action OnOpen;
    public event Action OnOpened;
    public event Action OnClose;
    public event Action OnClosed;

    private UniTask PlayOpenAnimation()
    {
        var taskCompletionSource = new UniTaskCompletionSource();
        openTweenerCore = moveRectTransform.DOLocalMoveX(moveDistXWhenOpen, moveDurationWhenOpen, snapping: true);
        openTweenerCore.onComplete += () => { taskCompletionSource.TrySetResult(); };
        return taskCompletionSource.Task;
    }
    
    private UniTask PlayCloseAnimation()
    {
        var taskCompletionSource = new UniTaskCompletionSource();
        closeTweenerCore = moveRectTransform.DOLocalMoveX(moveDistXWhenClose, moveDurationWhenClose, snapping: true);
        closeTweenerCore.onComplete += () =>
        {
            taskCompletionSource.TrySetResult();
        };
        return taskCompletionSource.Task;
    }

    public virtual async void Open()
    {
        OnOpen?.Invoke();
        await PlayOpenAnimation();
        OnOpened?.Invoke();
    }

    public virtual async void Close()
    {
        OnClose?.Invoke();
        await PlayCloseAnimation();
        OnClosed?.Invoke();
    }

    public virtual void Tick()
    {
        
    }
}
