using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationScenario
{
    internal class OrderClass
    {
        protected double senderId;
        protected long cardNo;
        protected double quantity;

        public OrderClass(double senderId, long cardNo, double quantity)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.quantity = quantity;
        }

        public double getSenderId() { return senderId; }

        public void setSenderid(double senderId) { this.senderId = senderId; }

        public long getCardNo() {  return cardNo; }

        public void setCardNo(long cardNo) { this.cardNo = cardNo; }

        public double getQuantity() { return quantity; }

        public void setQuantity(double quantity) {  this.quantity = quantity; }
    }
}
