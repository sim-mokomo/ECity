using System.Collections.Generic;
using System.Linq;
using MokomoGames.UI;
using UnityEngine;

namespace MokomoGames
{
    public class SoulSaleApplicationService
    {
        private UISoulSaleConfirm _saleConfirm;
        private UISoulSalePage _soulsalePage;
        private UserSoulList _userSoulList;
        private List<Soul> selectingSouls;
        private uint totalAcquisionSaleShizukuNum;
        private uint totalAcquisionSaleKarumaNum;

        public SoulSaleApplicationService(
            UISoulSaleConfirm saleConfirm,
            UserSoulList userSoulList,
            UISoulSalePage soulsalePage)
        {
            _saleConfirm = saleConfirm;
            _soulsalePage = soulsalePage;
            _userSoulList = userSoulList;

            totalAcquisionSaleShizukuNum = 0;
            totalAcquisionSaleKarumaNum = 0;
                
            selectingSouls = new List<Soul>();
            soulsalePage.OnTappedSoulCellIcon += soul =>
            {
                var tappedSoul = _userSoulList.Souls.FirstOrDefault(x => x.Equals(soul));
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

            soulsalePage.OnTappedSaleButton += () =>
            {
                _saleConfirm.Show(true);
                _saleConfirm.Begin(selectingSouls);
            };
            _saleConfirm.Show(false);
        }

        public void Tick()
        {
            
        }
    }
}