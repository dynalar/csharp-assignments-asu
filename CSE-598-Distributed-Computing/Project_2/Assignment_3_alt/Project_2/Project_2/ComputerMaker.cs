using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_2
{
    internal class ComputerMaker
    {
        private int priceCutsCounter;
        private readonly int maxPriceCuts = 10;
        private readonly PricingModel pricingModel;
        private readonly MultiCellBuffer buffer;
        private readonly Decoder decoder;
        private readonly List<Store> stores;

        public event EventHandler<PriceCutEventArgs> PriceCutEvent;

        public ComputerMaker(int maxPriceCuts, PricingModel pricingModel, MultiCellBuffer buffer, Decoder decoder)
        {
            this.maxPriceCuts = maxPriceCuts;
            this.pricingModel = pricingModel;
            this.buffer = buffer;
            this.decoder = decoder;
            this.stores = new List<Store>();
        }

        public void Start()
        {
            while (priceCutsCounter < maxPriceCuts)
            {
                // get the current price of the computer
                double currentPrice = pricingModel.CalculatePrice();

                // simulate a comparison if the price is lower than what was generated.
                if (currentPrice < pricingModel.PreviousPrice)
                {
                    // on price cut, call the
                    Console.WriteLine("Price Change detected!.");
                    OnPriceCut(currentPrice);
                }

                // sleep the thread for 100ms
                Thread.Sleep(100);
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

            // attach price cut event to each store, that triggers when there is a price cut.
            PriceCutEvent += store.OnPriceCut;
        }

        private void OnPriceCut(double newPrice)
        {
            PriceCutEvent?.Invoke(this, new PriceCutEventArgs(newPrice));
            priceCutsCounter++;
        }
    }
}
