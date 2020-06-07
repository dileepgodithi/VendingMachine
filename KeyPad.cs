using System;

namespace VendingMachineProject
{
    class KeyPad
    {
        public KeyPad()
        {

        }

        public int ReadKey()
        {
            string input = Console.ReadLine();
            int value;
            if(int.TryParse(input, out value) && value > 0)
            {
                return value;
            }
            return -1;
        }

    }
}