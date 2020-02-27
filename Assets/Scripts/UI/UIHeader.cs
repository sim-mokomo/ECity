using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
     public class UIHeader : MonoBehaviour
     {
          [SerializeField] private UIStamina staminaUi;
          [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
          [SerializeField] private TextMeshProUGUI yukichiNumText;
          [SerializeField] private TextMeshProUGUI coinNumText;
          [SerializeField] private TextMeshProUGUI mizuNumText;
          [SerializeField] private UIGaugeWithUpperLabel expGauge;
          public event Action OnTap;
          public event Action OnRelease;

          private void Awake()
          {
               staminaUi.OnTapedRecoveryButton += () => { recoveryStaminaDialog.Open(); };
               recoveryStaminaDialog.OnTappedCloseButton += () => { recoveryStaminaDialog.Close(); };
          }

          public void SetRank(uint rank,uint currentExp,uint needNextRankExp)
          {
               expGauge.SetRemainingValue(rank.ToString());
               expGauge.SetRemainingSliderValue(currentExp,needNextRankExp);
          }

          public void SetStamina(uint stamina,uint maxStamina)
          {
               staminaUi.SetCurrentValue(stamina,maxStamina);
               recoveryStaminaDialog.Initialize(
                    stamina,
                    maxStamina,
                    1,
                    1);
          }

          public void SetCoinNum(uint coinNum)
          {
               coinNumText.text = $"{coinNum}";
          }

          public void SetMizuNum(uint mizuNum)
          {
               mizuNumText.text = $"{mizuNum}";
          }

          public void SetYukichiNum(uint yukichiNum)
          {
               yukichiNumText.text = $"{yukichiNum}";
          }

          public void SetStaminaTime(uint minutes, uint seconds)
          {
               staminaUi.SetRecoveryTime(minutes,seconds);
          }

          public void Tick()
          {
               if (CommonInput.GetTouch() == TouchType.Began)
               {
                    var objs = CommonInput.GetTouchUIObjs();
                    var hitMe = objs.Any(x => x.gameObject.GetComponent<UIHeader>());
                    var hitButton = objs.Any(x => x.GetComponent<Button>());
                    if (hitMe && !hitButton)
                    {
                         OnTap?.Invoke();
                    }
               }

               if (CommonInput.GetTouch() == TouchType.Ended)
               {
                    OnRelease?.Invoke();
               }
          }
     }
}
