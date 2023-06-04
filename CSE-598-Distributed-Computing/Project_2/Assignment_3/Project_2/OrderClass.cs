using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    // simple order class, for keeping track of order data
    internal class OrderClass
    {
        public string SenderId { get; }
        public int CardNo { get; }
        public int Quantity { get; }

        public int orderNum { get; }
        public double totalAmount { get; set; }

        public DateTime orderPlacedDateTime { get; set; }

        public Action<double> ConfirmationCallback { get; set; }

        public OrderClass(string senderId, int cardNo, int quantity)
        {
            SenderId = senderId;
            CardNo = cardNo;
            Quantity = quantity;
        }
    }
}
