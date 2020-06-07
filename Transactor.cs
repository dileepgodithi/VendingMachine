using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    class Transactor
    {
        private int _amountAvailable;
        private HashSet<int> _validBills;
        public Transactor()
        {
            _amountAvailable = 100;
            _validBills = new HashSet<int>() {1, 2, 5, 10, 20, 50, 100 };
        }

        public bool AddAmount(int bill)
        {
            if (_validBills.Contains(bill))
            {
                _amountAvailable += bill;
                return true;
            }
            return false;
        }

        public HashSet<int> ValidBills
        {
            get
            {
                return _validBills;
            }
        }

        public bool GetChange(int userAmount)
        {
           if(userAmount > 0)
            {
                _amountAvailable -= userAmount;
                return true;
            }
            return false;
        }
    }
}
