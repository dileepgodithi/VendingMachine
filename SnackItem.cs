using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    class SnackItem : Item
    {
        public SnackItem(string itemName, int price)
            : base(itemName, price, "Snack")
        {

        }
    }
}
