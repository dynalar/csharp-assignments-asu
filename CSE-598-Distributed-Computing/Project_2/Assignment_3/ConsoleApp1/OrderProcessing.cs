using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OperationScenario
{
    internal class OrderProcessing
    {
        OrderClass order;

        public OrderProcessing(OrderClass receivedOrder) {
            order = receivedOrder;
        }

        public void processOrder(OrderClass order)
        {
            // initialize our thread for our order
            Thread orderProcessingThread = new Thread(orderProcessWorker);
            orderProcessingThread.Start();
        }

        public void orderProcessWorker() 
        {
            bool isValidCc = this.isValidCreditCard(order.getCardNo());
        }

        // accepts only visa credit cards, that start with 4 and with a total length of 16 digits.
        public bool isValidCreditCard(long ccNum)
        {
            int totalCcNums = ccNum.ToString().Length;
            bool isVisa = ccNum.ToString().Substring(0, 1) == "4";

            if (totalCcNums == 16 && isVisa)
            {
                return true;
            }

            return false;
        }
    }
}
