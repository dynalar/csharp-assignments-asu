using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OperationScenario
{
    // create delegate for notify
    public delegate void Notify();
    internal class ComputerMaker
    {
        // constructor
        public ComputerMaker() { }


        // set limit of price cuts allowed
        private const int TotalPriceCutsAllowed = 10;

        // define a price cut event
        public event Notify PriceChangeEvent;

        // receive strings from multi cell buffer and call decoder to convert to order object

        // call handlers in the stores if there is a price cut event

        // call the pricing model to check the price

        // every order received starts a new thread with OrderProcessing class

        //

        // receives an order and if it's valid, spins off a new thread to OrderProcessing class
        public void sendOrder(string order)
        {
            // call decoder and decode order to object
            Decoder decoder = new Decoder(order);
            OrderClass decodedOrder = decoder.decodeOrder(order);

            // pass our order to order processing class instance
            OrderProcessing orderProcessing = new OrderProcessing(decodedOrder);

            // send off order into its own thread for processing
            orderProcessing.processOrder(decodedOrder);
        }
    }
}
