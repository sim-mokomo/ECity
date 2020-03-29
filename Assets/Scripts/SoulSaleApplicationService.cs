﻿using System.Collections.Generic;
using System.Linq;
using MokomoGames.UI;
using UnityEngine;

namespace MokomoGames
{
    public class SoulSaleApplicationService
    {
        private UISoulSalePage _soulsalePage;
        private UserSoulList _userSoulList;
        private List<Soul> selectingSouls;
        private uint totalAcquisionSaleShizukuNum;
        private uint totalAcquisionSaleKarumaNum;

        public SoulSaleApplicationService(UserSoulList userSoulList,UISoulSalePage soulsalePage)
        {
            _soulsalePage = soulsalePage;
            _userSoulList = userSoulList;

            totalAcquisionSaleShizukuNum = 0;
            totalAcquisionSaleKarumaNum = 0;
                
            selectingSouls = new List<Soul>();
            soulsalePage.OnTappedSoulCellIcon += soul =>
            {
                var tappedSoul = userSoulList.Souls.FirstOrDefault(x => x.Equals(soul));
                var index = selectingSouls.FindIndex(x => x.Equals(tappedSoul));
                if (index >= 0)
                    selectingSouls.RemoveAt(index);
                else
                    selectingSouls.Add(tappedSoul);
                _soulsalePage.UpdateSelecting(selectingSouls);
                
                totalAcquisionSaleShizukuNum = (uint) selectingSouls.Sum(x => x.Config.SaleShizukuNum);
                totalAcquisionSaleKarumaNum = (uint) selectingSouls.Sum(x => x.Config.SaleKarumaNum);
                _soulsalePage.UpdateAcquisionShizukuNum(totalAcquisionSaleShizukuNum);
                _soulsalePage.UpdateAcquisionKarumaNum(totalAcquisionSaleKarumaNum);
            };

            soulsalePage.OnTappedSelectingClearButton += () =>
            {
                selectingSouls.Clear();
                _soulsalePage.UpdateSelecting(selectingSouls);

                totalAcquisionSaleShizukuNum = 0;
                totalAcquisionSaleKarumaNum = 0;
                _soulsalePage.UpdateAcquisionShizukuNum(totalAcquisionSaleShizukuNum);
                _soulsalePage.UpdateAcquisionKarumaNum(totalAcquisionSaleKarumaNum);
            };
        }

        public void Tick()
        {
            
        }
    }
}