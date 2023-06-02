using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxPriceCuts = 10;
            PricingModel pricingModel = new PricingModel();
            MultiCellBuffer buffer = MultiCellBuffer.Instance;
            Decoder decoder = new Decoder();

            ComputerMaker computerMaker = new ComputerMaker(maxPriceCuts, pricingModel, buffer, decoder);

            Store store1 = new Store("Store1");
            Store store2 = new Store("Store2");
            Store store3 = new Store("Store3");
            Store store4 = new Store("Store4");
            Store store5 = new Store("Store5");

            // make these into threads
            computerMaker.AddStore(store1);
            computerMaker.AddStore(store2);
            computerMaker.AddStore(store3);
            computerMaker.AddStore(store4);
            computerMaker.AddStore(store5);

            // start the main method thread for our computer maker, as specified in assignment
            Thread computerMakerThread = new Thread(computerMaker.Start);
            computerMakerThread.Start();

            Console.WriteLine("Started initial thread for ComputerMaker from main method.");

            // wait for the computermaker thread to complete operations
            computerMakerThread.Join();

            Console.WriteLine("ComputerMaker completed successfully. Press any key to quit!");
            Console.ReadKey();
        }
    }
}
