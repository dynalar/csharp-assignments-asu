using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class OrderProcessing
    {
        public void ProcessOrder(OrderClass order, double currentPrice, Action<OrderClass> confirmationCallback, Store store)
        {
            // check cc number
            if (IsValidCreditCard(order.CardNo))
            {
                // using the formula given in assignment criteria to calculate all of this information
                double totalAmount = currentPrice * order.Quantity + CalculateTax() + CalculateShippingHandling();

                // add total to order with shipping, tax, etc
                order.totalAmount = totalAmount;

                // pass in the order date time that was saved in the store earlier
                order.orderPlacedDateTime = store.orderPlacedDateTime;

                // call back the event action with total amount
                confirmationCallback(order);
            }
        }

        private bool IsValidCreditCard(int cardNo)
        {
            // checking the cc number just based on criteria in assignment
            return cardNo >= 4999 && cardNo <= 7001;
        }

        private double CalculateTax()
        {
            // just setting tax to 0.2 to make it easier
            return 0.2;
        }

        private double CalculateShippingHandling()
        {
            // random shipping and handling to $20
            // shipping from china is not cheap!
            return 20.0;
        }
    }
}
