using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;


namespace economy.Server
{
    public class HandMoney : BaseScript
    {
        public HandMoney()
        {
        }

        public int GetCurrentMoneyOnHand(string token)
        {
            string usernameQuery = $"SELECT username from players where token='{token}'";
            dynamic username = Exports["fivem-mysql"].raw(usernameQuery);
            string getHandMoneyQuery = $"SELECT quantity from inventory where username='{username[0][0]}' and name='{Currency.name}';";
            dynamic quantity = Exports["fivem-mysql"].raw(getHandMoneyQuery);

            if (quantity.Count == 0) { return 0; }

            return Int32.Parse(quantity[0][0]);
        }

        public int RemoveMoneyFromHand(string token, int quantityToRemove)
        {
            string usernameQuery = $"SELECT username from players where token='{token}'";
            dynamic username = Exports["fivem-mysql"].raw(usernameQuery);
            string getHandMoneyQuery = $"SELECT quantity from inventory where username='{username[0][0]}' and name='{Currency.name}';";
            dynamic quantity = Exports["fivem-mysql"].raw(getHandMoneyQuery);
            
            // -1 means you dont have money to pay
            if (quantity.Count == 0) { return -1; }

            int result_of_q = Int32.Parse(quantity[0][0]) - quantityToRemove;
            
            if (result_of_q < 0) { return -1; }

            // if the size of the money is equal to 0, lets remove the item from the inventory
            if (result_of_q == 0)
            {
                string deleteHandMoney = $"DELETE FROM inventory where username='{username[0][0]}' and name='{Currency.name}';";
                Exports["fivem-mysql"].raw(deleteHandMoney);
                return 0;
            }

            // updating the items from inventory
            string updateInventory = $"UPDATE `inventory` SET `quantity` = '{result_of_q}' WHERE `inventory`.`username` = '{username[0][0]}' AND `inventory`.`name` = '{Currency.name}';";
            Exports["fivem-mysql"].raw(updateInventory);

            // current quantity of the item in the inventory
            return result_of_q;
        }


    }
}