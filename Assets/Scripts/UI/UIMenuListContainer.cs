using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UniRx.Async.Triggers;
using UnityEngine;

public class UIMenuListContainer
{
    private readonly List<UIMenuList> _menuLists = new List<UIMenuList>();
    private UIMenuList Tail => _menuLists.LastOrDefault();

    public void Add(UIMenuList menuList)
    {
        if (_menuLists.Contains(menuList))
            return;
        for (var i = 0; i < _menuLists.Count; i++)
        {
            var menu = _menuLists[i];
            menu.transform.DOLocalMoveX(menu.endvalue - (200f * (i + 1)), 0.1f, true);
        }
        _menuLists.Add(menuList);
        menuList.OnClose -= RemoveTail;
        menuList.OnClose += RemoveTail;
        menuList.Open();
    }

    public void Remove(UIMenuList menulist)
    {
        if(!_menuLists.Contains(menulist))
            return;
        _menuLists.Remove(menulist);
        for (var i = 0; i < _menuLists.Count; i++)
        {
            var menu = _menuLists[i];
            menu.transform.DOLocalMoveX(menu.endvalue - (200f * i), 0.1f, true);
        }
    }

    private void RemoveTail()
    {
        Remove(Tail);
    }

    public void Tick()
    {
        if(Tail == null)
            return;
        if(Tail.IsOpening)
            Tail.Tick();      
    }
}
