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
        private List<Soul> selectingSouls = new List<Soul>();
        private uint totalAcquisionSaleShizukuNum = 0;
        private uint totalAcquisionSaleKarumaNum = 0;
        private bool SelectingAny => selectingSouls.Any();
        private bool AddableSoulCondicate => selectingSouls.Count < 10;

        public SoulSaleApplicationService(
            UISoulSaleConfirm saleConfirm,
            UserSoulList userSoulList,
            UISoulSalePage soulsalePage)
        {
            _saleConfirm = saleConfirm;
            _soulsalePage = soulsalePage;
            _userSoulList = userSoulList;
            
            soulsalePage.OnChangedTab += tabElement =>
            {
                var souls = tabElement.TabType == UITab.TabType.Battle
                    ? userSoulList.GetBattleSouls()
                    : userSoulList.GetMaterialSouls();

                var cells = _soulsalePage.MakeIcons(souls);
                _soulsalePage.UpdateSelecting(selectingSouls);
                foreach (var cell in cells)
                {
                    cell.OnClick += OnClickIcon;
                }
            };

            soulsalePage.OnTappedSelectingClearButton += () =>
            {
                selectingSouls.Clear();
                _soulsalePage.UpdateSelecting(selectingSouls);
                _soulsalePage.UpdateAcquisionShizukuNum(totalAcquisionSaleShizukuNum = 0);
                _soulsalePage.UpdateAcquisionKarumaNum(totalAcquisionSaleKarumaNum = 0);
            };

            soulsalePage.OnTappedSaleButton += () =>
            {
                if(!SelectingAny)
                    return;
                _saleConfirm.Show(true);
                _saleConfirm.Begin(selectingSouls);
            };
            
            _saleConfirm.Show(false);
            _saleConfirm.OnTappedCloseButton += () => _saleConfirm.Show(false);
        }
        
        private void OnClickIcon(Soul soul)
        {
            var tappedSoul = _userSoulList.Souls.FirstOrDefault(x => x.Equals(soul));
            var index = selectingSouls.FindIndex(x => x.Equals(tappedSoul));
            if (index >= 0)
                selectingSouls.RemoveAt(index);
            else
                if(AddableSoulCondicate)
                    selectingSouls.Add(tappedSoul);
            _soulsalePage.UpdateSelecting(selectingSouls);
                
            totalAcquisionSaleShizukuNum = (uint) selectingSouls.Sum(x => x.Config.SaleShizukuNum);
            totalAcquisionSaleKarumaNum = (uint) selectingSouls.Sum(x => x.Config.SaleKarumaNum);
            _soulsalePage.UpdateAcquisionShizukuNum(totalAcquisionSaleShizukuNum);
            _soulsalePage.UpdateAcquisionKarumaNum(totalAcquisionSaleKarumaNum);
        }

        public void Tick()
        {
            
        }
    }
}