using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UniRx.Async;
using UnityEngine;

public class UIMenuList : MonoBehaviour, IOpenable
{
    private TweenerCore<Vector3, Vector3, VectorOptions> closeTweenerCore;
    [SerializeField] private float moveDistXWhenClose;
    [SerializeField] private float moveDistXWhenOpen;
    [SerializeField] private float moveDurationWhenClose;
    [SerializeField] private float moveDurationWhenOpen;
    [SerializeField] private RectTransform moveRectTransform;
    public Action OnRequestedClose;
    private TweenerCore<Vector3, Vector3, VectorOptions> openTweenerCore;
    
    public enum PageType
    {
        None,
        SoulList,
        SoulSale,
    }
    public event Action<PageType> OnRequest; 

    public float MoveDurationWhenOpen => moveDurationWhenOpen;
    public bool IsOpening => openTweenerCore != null || closeTweenerCore == null || closeTweenerCore.IsActive();
    public event Action OnOpen;
    public event Action OnOpened;
    public event Action OnClose;
    public event Action OnClosed;

    public virtual async void Open(bool immediately = false)
    {
        OnOpen?.Invoke();
        await PlayOpenAnimation(immediately);
        OnOpened?.Invoke();
    }

    public virtual async void Close(bool immediately = false)
    {
        OnClose?.Invoke();
        await PlayCloseAnimation(immediately);
        OnClosed?.Invoke();
    }

    private UniTask PlayOpenAnimation(bool immediately = false)
    {
        var taskCompletionSource = new UniTaskCompletionSource();
        openTweenerCore =
            moveRectTransform.DOLocalMoveX(moveDistXWhenOpen, immediately ? 0f : moveDurationWhenOpen, true);
        openTweenerCore.onComplete += () => { taskCompletionSource.TrySetResult(); };
        return taskCompletionSource.Task;
    }

    private UniTask PlayCloseAnimation(bool immediately = false)
    {
        var taskCompletionSource = new UniTaskCompletionSource();
        closeTweenerCore = moveRectTransform.DOLocalMoveX(moveDistXWhenClose, immediately ? 0f : moveDurationWhenClose,
            true);
        closeTweenerCore.onComplete += () => { taskCompletionSource.TrySetResult(); };
        return taskCompletionSource.Task;
    }

    public virtual void Tick()
    {
    }

    protected void RequestPage(PageType pageType)
    {
        OnRequest?.Invoke(pageType);
    }
}