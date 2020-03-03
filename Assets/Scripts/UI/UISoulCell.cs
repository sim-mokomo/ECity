using System;
using MokomoGames.Protobuf;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulCell : MonoBehaviour
    {
        public float Height => _rectTransform.rect.height;
        public float Width => _rectTransform.rect.width;
        private RectTransform _rectTransform;
        [SerializeField] private Image attributeIcon;
        [SerializeField] private Image characterIcon;
        [SerializeField] private UIStars stars;
        
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Begin(SoulTableRecord record)
        {
            //TODO: 属性アイコン
            //TODO: キャラ画像
            stars.Show(record.Rarity);
        }
        
        public void Show(bool show)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(show);
            }
        }
    }
}