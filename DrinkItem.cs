using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    class DrinkItem : Item
    {
        public DrinkItem(string itemName, int price)
            : base(itemName, price, "Drink")
        {

        }
    }
}
