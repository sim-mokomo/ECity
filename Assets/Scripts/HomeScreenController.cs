using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using UnityEngine;

public class HomeScreenController : MonoBehaviour
{
    [SerializeField] private UIHeader headerUi;

    public void Begin()
    {
        PlayerSaveDataRepository.GetPlayerSaveData(PlayerSaveData.Empty, playerSaveData =>
        {
            headerUi.SetStamina(
                stamina:playerSaveData.Stamina, 
                maxStamina: 999
                );
        });
    }

    public void Tick()
    {
        
    }
}
