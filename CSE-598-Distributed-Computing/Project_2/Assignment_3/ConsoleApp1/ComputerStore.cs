using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class ComputerStore
    {
        OrderClass order;
        public ComputerStore(OrderClass incomingOrder) 
        {
            order = incomingOrder;
        }

        public string returnEncodedOrder(OrderClass incomingOrder)
        {
            Encoder encoder = new Encoder();

            return encoder.encodeOrder(incomingOrder);
        }

        public void sendEncodedOrder(string encodedOrder) { 
        }
    }
}
