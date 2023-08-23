using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;


namespace economy.Server
{
    public class RemoveHandMoney : BaseScript
    {
        HandMoney handMoney = new HandMoney();

        public RemoveHandMoney()
        {
            EventHandlers["removeHandMoney"] += new Action<Player, string, int>(RemoveHandMoneyEvent);
        }

        private void RemoveHandMoneyEvent([FromSource] Player user, string token, int quantityToRemove)
        {
            TriggerClientEvent(user, "removeMoneyEventToClient", handMoney.RemoveMoneyFromHand(token, quantityToRemove));
        }
    }
}