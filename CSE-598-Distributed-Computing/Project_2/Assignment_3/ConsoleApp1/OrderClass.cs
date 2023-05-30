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
        protected double cardNo;
        protected double quantity;

        public double getSenderId() { return senderId; }

        public void setSenderid(double senderId) { this.senderId = senderId; }

        public double getCardNo() {  return cardNo; }

        public void setCardNo(double cardNo) { this.cardNo = cardNo; }

        public double getQuantity() { return quantity; }

        public void setQuantity(double quantity) {  this.quantity = quantity; }
    }
}
