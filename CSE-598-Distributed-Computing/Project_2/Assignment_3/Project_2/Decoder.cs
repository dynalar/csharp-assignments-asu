using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class Decoder
    {
        public OrderClass Decode(string encodedOrder)
        {
            // decode by exploding by colon
            string[] parts = encodedOrder.Split(':');

            // get each piece of the decoded order
            string senderId = parts[0];
            int cardNo = int.Parse(parts[1]);
            int quantity = int.Parse(parts[2]);

            // pass in information to generate order object
            return new OrderClass(senderId, cardNo, quantity);
        }
    }
}
