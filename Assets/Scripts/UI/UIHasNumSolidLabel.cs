using TMPro;
using UnityEngine;

namespace MokomoGames.UI
{
    public class UIHasNumSolidLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hasNum;

        public void UpdateHasNum(uint currentNum, uint capacity)
        {
            hasNum.text = $"{currentNum}/{capacity}";
        }
    }
}