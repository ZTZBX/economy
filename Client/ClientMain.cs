using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace economy.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            EventHandlers["sendHandMoneyOnClientSide"] += new Action<int>(UpdateHandMoney);
            EventHandlers["removeMoneyEventToClient"] += new Action<int>(removeMoneyEventToClient);
            EventHandlers["updateCurrencyToClient"] += new Action<string>(UpdateCurrencyToClient);
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            updatingMoney();
            TriggerServerEvent("getCurrency", Exports["core-ztzbx"].playerToken());
        }

        async private void updatingMoney()
        {
            while (true)
            {
                await Delay(1000);
                TriggerServerEvent("getHandMoney", Exports["core-ztzbx"].playerToken());
            }

        }

        private void removeMoneyEventToClient(int quantity)
        {
            if (quantity != -1)
            {
                Money.hand = quantity;
                return;
            }
        }

        private void UpdateCurrencyToClient(string currency)
        {
            Money.currency = currency;
        }

        private void UpdateHandMoney(int quantity)
        {
            Money.hand = quantity;
        }
    }
}