using TMPro;
using UnityEngine;

public class UIHasYukichi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yukichiNum;

    public void SetYukichiNum(uint yukichiNum)
    {
        this.yukichiNum.text = $"{yukichiNum}";
    }
}