using System.Collections.Generic;
using System.Linq;
using MokomoGames.UI;

namespace MokomoGames
{
    public class SoulSaleApplicationService
    {
        private UISoulSalePage _soulsalePage;
        private UserSoulList _userSoulList;
        private List<Soul> selectingSouls;

        public SoulSaleApplicationService(UserSoulList userSoulList,UISoulSalePage soulsalePage)
        {
            _soulsalePage = soulsalePage;
            _userSoulList = userSoulList;
                
            selectingSouls = new List<Soul>();
            soulsalePage.OnTappedSoulCellIcon += soul =>
            {
                if (selectingSouls.Any(x => x == soul))
                    selectingSouls.Remove(soul);
                else
                    selectingSouls.Add(soul);
                _soulsalePage.UpdateSelecting(selectingSouls);
            };
        }

        public void Tick()
        {
            
        }
    }
}