using System;
using System.Collections.Generic;
using UnityEngine;

namespace MokomoGames
{
    public class NestedMenuController : MonoBehaviour
    {
        private UIMenuListContainer menuListContainer = new UIMenuListContainer();
        [SerializeField] private List<NestedMenuConfigration> nestedMenuConfigrations;
        public List<NestedMenuConfigration> NestedMenuConfigrations => nestedMenuConfigrations;

        public void Entry()
        {
            foreach (var config in nestedMenuConfigrations)
            {
                config.Trigger.OnDetect += () => { menuListContainer.Add(config.MenuList); };
            }
        }

        public void Tick()
        {
            menuListContainer.Tick();
        }

        public void Release()
        {
            menuListContainer.RemoveAll();
        }
    }
    
    [Serializable]
    public class NestedMenuConfigration
    {
        [SerializeField] private Trigger trigger;
        [SerializeField] private UIMenuList menuList;

        public Trigger Trigger => trigger;
        public UIMenuList MenuList => menuList;
    }
}