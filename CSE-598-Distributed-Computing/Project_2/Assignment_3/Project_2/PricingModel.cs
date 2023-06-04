using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class PricingModel
    {
        public double PreviousPrice { get; private set; }

        public double CalculatePrice()
        {
            Random random = new Random();
            double price = random.Next(500, 2000);

            double rand = random.NextDouble();

            // 50% chance of generating a lower price
            if (rand < 0.5)
            {
                PreviousPrice = price;
            }

            return price;
        }
    }
}
