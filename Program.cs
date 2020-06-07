using System;

namespace VendingMachineProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.ReadLine();

            Item[,] items= new Item[3,4];

            items[0, 0] = new ChocolateItem("Dairy Milk", 3);
            items[0, 1] = new ChocolateItem("Snickers", 7);
            items[0, 2] = new ChocolateItem("Kitkat", 5);
            items[0, 3] = new ChocolateItem("5Star", 4);

            items[1, 0] = new SnackItem("Cheetos", 2);
            items[1, 1] = new SnackItem("Lays", 3);
            items[1, 2] = new SnackItem("Dorito", 4);
            items[1, 3] = new SnackItem("Haldiram", 5);

            items[2, 0] = new DrinkItem("Coke", 2);
            items[2, 1] = new DrinkItem("Pepsi", 2);
            items[2, 2] = new DrinkItem("Sprite",3);
            items[2, 3] = new DrinkItem("Frooti",5);

            VendingMachine vm = new VendingMachine(items);

            vm.PowerOn();
        }
    }
}
