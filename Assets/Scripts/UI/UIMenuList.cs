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
    [SerializeField] private RectTransform _rectTransform;
    public void Open()
    {
        _rectTransform.DOLocalMoveX(endvalue, duration, snapping: true);
    }

    public void Close()
    {
        _rectTransform.DOLocalMoveX(value, d, snapping: true);
    }
}
