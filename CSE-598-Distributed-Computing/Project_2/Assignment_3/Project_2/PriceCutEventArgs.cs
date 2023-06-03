using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    // class that stores arguments for price cut event.
    // really for encapsulation and keeping data where it belongs.
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
