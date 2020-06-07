using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VendingMachineProject
{
    class VendingMachine
    {
        private Item[,] _shelve;
        private Display _displayScreen;
        private Transactor _transactor;
        private KeyPad _keypad;
        private int _userAmount;

        public VendingMachine(Item[,] items)
        {
            _shelve = items;
            _displayScreen = new Display();
            _transactor = new Transactor();
            _keypad = new KeyPad();
            _userAmount = 0;
        }

        private int UserAmount { 
            get 
            {
                return _userAmount;
            }
        }

        public void PowerOn()
        {
            _displayScreen.WelcomeMessage();
            int key = 0;

            while (true)
            {
                _displayScreen.DisplayMessage();
                Console.WriteLine();
                key = _keypad.ReadKey();
                switch (key)
                {
                    //Feeding money
                    case 1:
                        int bill;
                        _displayScreen.DisplayMessage("Enter a valid bill.");
                        bill = _keypad.ReadKey();
                        if (_transactor.AddAmount(bill))
                        {
                            _userAmount += bill;
                            _displayScreen.DisplayMessage($"Current balance is ${_userAmount}");
                        }
                        else
                        {
                            _displayScreen.DisplayMessage($"Please enter a valid amount. Current balance is ${_userAmount}");
                            _displayScreen.DisplayMessage("Valid bills are {1, 2, 5, 10, 20, 50, 100}");
                        }
                        break;

                    //Select product and transact
                    case 2:
                        int slot;
                        _displayScreen.DisplayMessage(_shelve);
                        _displayScreen.DisplayMessage($"Your current balance is ${_userAmount}");
                        _displayScreen.DisplayMessage("Please select the product#");
                        slot = _keypad.ReadKey();
                        BuyProduct(slot);
                        break;
                        
                    //Show balance
                    case 3:
                        _displayScreen.DisplayMessage($"Available balance: ${UserAmount}");
                        break;

                    //Get change
                    case 4:
                        if (_transactor.GetChange(_userAmount))
                        {
                            _displayScreen.DisplayMessage($"Please collect your change: ${_userAmount}");
                            _userAmount = 0;
                        }
                        else
                        {
                            _displayScreen.DisplayMessage($"Sorry. You do not have any change left.");
                        }

                        break;

                    //Quit
                    case 5:
                        if(_userAmount == 0)
                        {
                            _displayScreen.DisplayMessage("Thank you for visiting!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            _displayScreen.WelcomeMessage();
                        }
                        else
                        {
                            _displayScreen.DisplayMessage($"Please collect your change ${_userAmount} before leaving.");
                            _transactor.GetChange(_userAmount);
                            Thread.Sleep(3000);
                            Console.Clear();
                            _displayScreen.WelcomeMessage();
                        }

                        break;

                    default:
                        _displayScreen.DisplayMessage("Please make a valid selection!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        _displayScreen.WelcomeMessage();
                        break;


                }
            }
        }

        private void BuyProduct(int slot)
        {
            int column = slot % 10 - 1;
            int row = slot / 10 - 1;
            if(row < 0 || row > _shelve.GetUpperBound(0) 
                || column < 0 || column > _shelve.GetUpperBound(1))
            {
                _displayScreen.DisplayMessage("Please enter a valid product number.");
                return;
            }

            var item = _shelve[row, column];
            if (item == null)
            {
                _displayScreen.DisplayMessage("Empty slot. Please make a new selection.");
                return;
            }

            if (item.Price > _userAmount)
            {
                _displayScreen.DisplayMessage($"Not enough balance to buy the item {item.ItemName}");
                return;

            }

            _displayScreen.DisplayMessage($"Transaction successful. Please collect the item.");
            _displayScreen.DisplayMessage($"Item Details: {item.DisplayMessage()}");
            _userAmount -= _shelve[row, column].Price;
            _shelve[row, column] = null;
            Thread.Sleep(2000);

        }
    }
}
