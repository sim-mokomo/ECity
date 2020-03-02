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
    private const float OffsetBetweenMenu = 200f;
    private const float OffsetMoveDuration = 0.1f;

    public void Add(UIMenuList menuList)
    {
        if (_menuLists.Contains(menuList))
            return;
        foreach (var menuGroup in _menuLists.Select((x, i) => new {menu = x, index = i}))
        {
            var menu = menuGroup.menu;
            menu.transform.DOLocalMoveX(menu.MoveDurationWhenOpen - OffsetBetweenMenu * (menuGroup.index + 1), OffsetMoveDuration, true);
        }
        _menuLists.Add(menuList);
        menuList.OnRequestedClose -= RemoveTail;
        menuList.OnRequestedClose += RemoveTail;
        menuList.Open();
    }

    public void Remove(UIMenuList menulist)
    {
        if(!_menuLists.Contains(menulist))
            return;
        _menuLists.Remove(menulist);
        menulist.Close();

        foreach (var menuGroup in _menuLists.Select( (x,i) => new {menu=x,index=i}))
        {
            var menu = menuGroup.menu;
            menu.transform.DOLocalMoveX(menu.MoveDurationWhenOpen - (OffsetBetweenMenu * menuGroup.index), OffsetMoveDuration, true);
        }
    }

    private void RemoveTail()
    {
        Remove(Tail);
    }

    public void RemoveAll()
    {
        _menuLists.ForEach(x => x.Close(true));
        _menuLists.Clear();
    }

    public void Tick()
    {
        if(Tail == null)
            return;
        if(Tail.IsOpening)
            Tail.Tick();      
    }
}
