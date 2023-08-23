using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace economy.Client
{
    public class Exports : BaseScript
    {
       
        public Exports()
        {
            Exports.Add("getHandMoney", new Func<int>(getHandMoney));
            Exports.Add("removeHandMoney", new Action<int>(RemoveHandMoney));
            Exports.Add("addHandMoney", new Action<int>(AddHandMoney));
        }

        private int getHandMoney()
        {
            TriggerServerEvent("getHandMoney", Exports["core-ztzbx"].playerToken());
            return Money.hand;
        }

        private void RemoveHandMoney(int quantity)
        {
            TriggerServerEvent("removeHandMoney", Exports["core-ztzbx"].playerToken(), quantity);
        }

        private void AddHandMoney(int quantity)
        {
            Exports["inventory"].addItemInventory(Money.currency, quantity);
            Money.hand += quantity;
        }
    }
}