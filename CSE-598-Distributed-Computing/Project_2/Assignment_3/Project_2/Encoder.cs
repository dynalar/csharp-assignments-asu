using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class Encoder
    {
        public string Encode(OrderClass order)
        {
            // Implement your encoding logic here
            // This is just a placeholder
            return $"{order.SenderId}:{order.CardNo}:{order.Quantity}";
        }
    }
}
