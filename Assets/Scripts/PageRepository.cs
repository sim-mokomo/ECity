using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MokomoGames.UI
{
    public class PageRepository : MonoBehaviour
    {
        [SerializeField] private List<Page> pages;

        public List<Page> Pages => pages;

        public IReadOnlyList<ISoulPage> SoulPages => 
            pages
                .OfType<ISoulPage>()
                .ToList();
        
        public enum PageType
        {
            None,
            SoulList,
            SoulSale,
        }

        public IPage GetPage(PageType pageType)
        {
            return pages.FirstOrDefault(x => x.PageType == pageType);
        }
    }
}