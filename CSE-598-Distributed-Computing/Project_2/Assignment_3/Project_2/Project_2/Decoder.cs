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
            // Implement your decoding logic here
            // This is just a placeholder
            string[] parts = encodedOrder.Split(':');
            string senderId = parts[0];
            int cardNo = int.Parse(parts[1]);
            int quantity = int.Parse(parts[2]);
            return new OrderClass(senderId, cardNo, quantity);
        }
    }
}
