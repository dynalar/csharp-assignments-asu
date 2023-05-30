using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class Program
    {
        // main class that runs all of our operations
        static void Main(string[] args)
        {
            // simulate list of 5 orders that have just come in from client side
            List<string> orderList = new List<string>();
            orderList.Add("replaceWithSenderId,4111111111111111,5");
            orderList.Add("replaceWithSenderId,4222222222222222,2");
            orderList.Add("replaceWithSenderId,4333333333333333,1");
            orderList.Add("replaceWithSenderId,4444444444444444,3");
            orderList.Add("replaceWithSenderId,4124515251525255,2");


            // run threads for 5 orders that are incoming from the computer store
            foreach (string order in orderList)
            {
                // new class instance
                ComputerStore computerStore = new ComputerStore();

                Thread computerStoreThread = new Thread(new ComputerStore());
                computerStoreThread.Start();
            }
        }
    }
}
