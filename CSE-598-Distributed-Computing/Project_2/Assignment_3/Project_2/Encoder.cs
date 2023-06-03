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
            // we encode using this colon delineated structure
            // that way, we can explode it later into separate tokens
            return $"{order.SenderId}:{order.CardNo}:{order.Quantity}";
        }
    }
}
