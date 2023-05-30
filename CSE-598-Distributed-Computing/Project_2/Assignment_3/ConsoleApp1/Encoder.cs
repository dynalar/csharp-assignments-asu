using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class Encoder
    {
        public string encodeOrder(OrderClass orderClass)
        {
            // return our order in this comma dileneated format
            return orderClass.getSenderId() + "," + orderClass.getQuantity() + "," + orderClass.getCardNo();
        }
    }
}
