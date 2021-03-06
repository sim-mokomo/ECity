﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIStars : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
        [SerializeField] private RectTransform horizontalLayoutRectTransform;
        [SerializeField] private List<Image> stars;

        public void Show(uint starNum)
        {
            for (var i = 0; i < stars.Count; i++)
            {
                var star = stars[i];
                star.gameObject.SetActive(i < starNum);
            }

            var sample = stars.FirstOrDefault();
            horizontalLayoutRectTransform.sizeDelta = new Vector2(
                sample.rectTransform.sizeDelta.x * starNum + horizontalLayoutGroup.spacing * starNum,
                horizontalLayoutRectTransform.sizeDelta.y);
        }
    }
}