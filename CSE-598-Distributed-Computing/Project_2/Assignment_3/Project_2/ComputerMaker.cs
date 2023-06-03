﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_2
{
    internal class ComputerMaker
    {
        // total counter of price cuts that have taken placed
        private int priceCutsCounter;

        // max price cuts allowed
        private readonly int maxPriceCuts = 10;

        private readonly PricingModel pricingModel;
        private readonly MultiCellBuffer buffer;
        private readonly Decoder decoder;
        private readonly List<Store> stores;

        public event EventHandler<PriceCutEventArgs> PriceCutEvent;

        public ComputerMaker(PricingModel pricingModel, MultiCellBuffer buffer, Decoder decoder)
        {
            this.pricingModel = pricingModel;
            this.buffer = buffer;
            this.decoder = decoder;
            this.stores = new List<Store>();
        }

        public void Start()
        {
            // check if a simulated price cut has occurred
            while (priceCutsCounter < maxPriceCuts)
            {
                // get the current price of the computer
                double currentPrice = pricingModel.CalculatePrice();

                // simulate a comparison if the price is lower than what was generated.
                if (currentPrice < pricingModel.PreviousPrice)
                {
                    // on price cut, call the event for when price cut occurs
                    Console.WriteLine("Price Change detected!");
                    OnPriceCut(currentPrice);

                    // get an order from the multi cell buffer
                    OrderClass decodedOrder = decoder.Decode(buffer.GetOneCell());
                    
                    // ensure the order arrived correctly and is not empty.
                    if (decodedOrder != null)
                    {
                        // find the store based off the store name and sender id.
                        foreach (Store store in stores)
                        {
                            if(store.name == decodedOrder.SenderId)
                            {
                                // Start a new thread to process the order
                                OrderProcessing orderProcessing = new OrderProcessing();

                                Thread orderProcessingThread = new Thread(
                                    () => orderProcessing.ProcessOrder(decodedOrder, currentPrice, store.confirmationCallback, store)
                                );

                                orderProcessingThread.Start();
                                break;
                            }
                        }
                    }
                }

                // sleep the thread for 100ms
                Thread.Sleep(300);
            }

            // abort the thread if we reach a maximum
            if (priceCutsCounter == maxPriceCuts)
            {
                Thread.CurrentThread.Abort();
            }
        }

        public void AddStore(Store store)
        {
            stores.Add(store);

            // subscribe the store to the price cut event
            PriceCutEvent += store.OnPriceCut;
        }

        private void OnPriceCut(double newPrice)
        {
            // call the PriceCutEvent inside the Store class to trigger action.
            PriceCutEvent?.Invoke(this, new PriceCutEventArgs(newPrice));
            priceCutsCounter++;

            Console.WriteLine("Total Price Cuts: " +  priceCutsCounter);
        }
    }
}
