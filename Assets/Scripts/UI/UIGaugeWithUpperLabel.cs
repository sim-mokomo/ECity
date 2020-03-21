using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
    public class UIGaugeWithUpperLabel : MonoBehaviour
    {
        [SerializeField] private Slider remainingSlider;
        [SerializeField] private TextMeshProUGUI remainingValueText;

        public void Awake()
        {
            remainingSlider.interactable = false;
        }

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