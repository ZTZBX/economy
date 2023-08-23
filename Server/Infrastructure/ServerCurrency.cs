using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;


namespace economy.Server
{
    public class ServerCurrency : BaseScript
    {
        public ServerCurrency()
        {
            EventHandlers["onResourceStart"] += new Action<string>(onResourceStart);
            EventHandlers["getCurrency"] += new Action<Player>(GetCurrency);
            
        }

        private void GetCurrency([FromSource] Player user)
        {
           TriggerClientEvent(user, "updateCurrencyToClient", Currency.name);
        }

        private void onResourceStart(string resourceName)
        {
            Currency.name = GetServerCurrency();
            
        }

        private string GetServerCurrency()
        {
            string query = $"SELECT currency_on_server from economyonserver";
            dynamic currency = Exports["fivem-mysql"].raw(query);
            return currency[0][0];
        }


    }
}