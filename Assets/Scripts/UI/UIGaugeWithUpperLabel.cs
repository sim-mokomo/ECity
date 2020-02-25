using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
    public class UIGaugeWithUpperLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI remainingValueText;
        [SerializeField] private Slider remainingSlider;

        public void SetRemainingValue(string valueStr)
        {
            remainingValueText.text = valueStr;
        }

        public void SetRemainingSliderValue(float current, float max)
        {
            remainingSlider.maxValue = max;
            remainingSlider.value = current;
        }
    }
}
