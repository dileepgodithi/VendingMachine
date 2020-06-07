using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    abstract class Item
    {
        private string _itemName;
        private int _price;
        private readonly string _itemType;

        public string ItemName
        {
            get
            {
                return _itemName;
            }
        }

        public string ItemType
        {
            get
            {
                return _itemType;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
        }

        public Item(string itemName,  int price, string itemType)
        {
            _itemName = itemName;
            _price = price;
            _itemType = itemType;
        }

        public string DisplayMessage()
        {
            return $"Name : {ItemName} Price : ${Price} Type : {ItemType}";
        }
    }
}
