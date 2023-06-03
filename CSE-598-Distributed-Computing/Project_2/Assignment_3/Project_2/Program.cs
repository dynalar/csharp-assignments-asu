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
            PricingModel pricingModel = new PricingModel();
            MultiCellBuffer buffer = MultiCellBuffer.Instance;
            Decoder decoder = new Decoder();

            // computerMaker instance
            ComputerMaker computerMaker = new ComputerMaker(pricingModel, buffer, decoder);

            // stores are defined with a name. must be unique. tied with sender id.
            Store store1 = new Store("Store1");
            Store store2 = new Store("Store2");
            Store store3 = new Store("Store3");
            Store store4 = new Store("Store4");
            Store store5 = new Store("Store5");

            // adding multiple stores to our computer maker.
            computerMaker.AddStore(store1);
            computerMaker.AddStore(store2);
            computerMaker.AddStore(store3);
            computerMaker.AddStore(store4);
            computerMaker.AddStore(store5);

            // start the main method thread for our computer maker, as specified in assignment
            Thread computerMakerThread = new Thread(computerMaker.Start);
            computerMakerThread.Start();

            // signal start of program
            Console.WriteLine("Started initial thread for ComputerMaker from main method.");

            // wait for the computermaker thread to complete operations
            computerMakerThread.Join();

            // runs once computerMakerThread is killed or ends
            Console.WriteLine("ComputerMaker completed successfully. Press any key to quit!");
            Console.ReadKey();
        }
    }
}
