using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class PricingModel
    {
        private const double MaxPrice = 2000;
        private const double MinPrice = 500;
        private Random random;

        public PricingModel() 
        {
            random = new Random();    
        }

        public double decidePrice()
        {
            return random.NextDouble() * (MaxPrice - MinPrice) + MinPrice;
        }
    }
}
