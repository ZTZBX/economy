using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;


namespace economy.Server
{
    public class GetHandMoney : BaseScript
    {
        HandMoney handMoney = new HandMoney();

        public GetHandMoney()
        {
            EventHandlers["getHandMoney"] += new Action<Player, string>(GetHandMoneyEvent);
        }

        private void GetHandMoneyEvent([FromSource] Player user, string token)
        {
            TriggerClientEvent(user, "sendHandMoneyOnClientSide", handMoney.GetCurrentMoneyOnHand(token));
        }
    }
}