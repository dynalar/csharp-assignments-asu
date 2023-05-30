using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class Decoder
    {
        public OrderClass decodeOrder(string order)
        {
            string[] orderAttributes = order.Split(',');
            
            OrderClass orderClass = new OrderClass();

            double senderId = double.Parse(orderAttributes[0]);
            double quantity = double.Parse(orderAttributes[1]);
            double cardNo = double.Parse(orderAttributes[2]);

            orderClass.setSenderid(senderId);
            orderClass.setQuantity(quantity);
            orderClass.setCardNo(cardNo);

            return orderClass;
        }
    }
}
