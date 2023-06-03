using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_2
{
    internal class Store
    {
        public string name;
        private double currentPrice;
        public DateTime orderPlacedDateTime;

        public Store(string name)
        {
            this.name = name;
        }

        public void OnPriceCut(object sender, PriceCutEventArgs e)
        {
            currentPrice = e.NewPrice;
            // Calculate the number of computers to order based on the current and previous prices
            int quantity = CalculateOrderQuantity(currentPrice, e.PreviousPrice);

            // Create an order object
            OrderClass order = new OrderClass(name, GenerateCreditCardNumber(), quantity);

            // Encode the order object into a string
            Encoder encoder = new Encoder();
            string encodedOrder = encoder.Encode(order);

            // Save the timestamp for the order before we set it in the cell
            orderPlacedDateTime = DateTime.Now;

            // Send the order to the multi-cell buffer
            MultiCellBuffer.Instance.SetOneCell(encodedOrder);
        }

        // final confirmation callback, signalling that the order has been completed.
        // Action<> is the NEW way of storing callbacks, instead of using delegates
        // we pass the order, as we store the final price, timestamp, etc. in the order.
        public Action<OrderClass> confirmationCallback = order =>
        {
            // print the total amount, and the time order was processed
            Console.WriteLine("Order has been processed for: " + 
                order.SenderId + "\nTotal: $" + order.totalAmount + "\nTotal Quantity: " + order.Quantity);

            Console.WriteLine($"Order processed at: {order.orderPlacedDateTime} \n");
        };

        private int GenerateCreditCardNumber()
        {
            // Generate a random credit card number
            Random random = new Random();
            return random.Next(5000, 7001);
        }

        private int CalculateOrderQuantity(double currentPrice, double previousPrice)
        {
            // order calculation???? I feel like I did this wrong.
            return (int)(1000 / (currentPrice - previousPrice));
        }
    }
}
