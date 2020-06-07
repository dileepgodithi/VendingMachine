using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    class Display
    {
        public Display()
        {

        }

        public void WelcomeMessage()
        {
            Console.WriteLine(@"
.------------------------------------------------------------------------------.
| /\   /\___ _ __   __| (_)_ __   __ _    /\/\   __ _  ___| |__ (_)_ __   ___  |
| \ \ / / _ | '_ \ / _` | | '_ \ / _` |  /    \ / _` |/ __| '_ \| | '_ \ / _ \ |
|  \ V |  __| | | | (_| | | | | | (_| | / /\/\ | (_| | (__| | | | | | | |  __/ |
|   \_/ \___|_| |_|\__,_|_|_| |_|\__, | \/    \/\__,_|\___|_| |_|_|_| |_|\___| |
|                                 |___/                                        |
'------------------------------------------------------------------------------'");
        }

        public void DisplayMessage()
        {
            Console.Write(@"
.-----.---------------------.
|Press|       Action        |
|-----|---------------------|
|  1  |    Feed Money       |
|  2  |    Select a Product |
|  3  |    Show Balance     |
|  4  |    Get Change       |
|  5  |    Quit             |
'-----'---------------------'
Please select your option"
);
        }

        //product display
        public void DisplayMessage(Item[,] items)
        {
            for(int i = 0; i <= items.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= items.GetUpperBound(1); j++)
                {
                    if(items[i,j] != null)
                    {
                        Console.Write($"|{i+1}{j+1} {items[i, j].ItemName} ${items[i, j].Price}|\t");
                    }
                    else
                    {
                        Console.Write($"|{i+1}{j+1} ---Empty---|\t");
                    }

                }
                Console.WriteLine();
            }
        }

        //custom message
        public void DisplayMessage(string message)
        {
            //Console.WriteLine();
            Console.WriteLine(message);
        }
    }
}
