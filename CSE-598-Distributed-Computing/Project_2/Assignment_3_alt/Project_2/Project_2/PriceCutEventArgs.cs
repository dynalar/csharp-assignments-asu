using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class PriceCutEventArgs
    {
        public double NewPrice { get; }
        public double PreviousPrice { get; }

        public PriceCutEventArgs(double newPrice)
        {
            NewPrice = newPrice;
        }
    }
}
