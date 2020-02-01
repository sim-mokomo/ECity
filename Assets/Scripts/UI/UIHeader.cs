using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using UnityEngine;

namespace MokomoGames
{
     public class UIHeader : MonoBehaviour
     {
          [SerializeField] private UIStamina staminaUi;
          [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
          
          private void Awake()
          {
               staminaUi.OnTapedRecoveryButton += () => { recoveryStaminaDialog.Open(); };
               recoveryStaminaDialog.OnTappedCloseButton += () => { recoveryStaminaDialog.Close(); };
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
     }
}
