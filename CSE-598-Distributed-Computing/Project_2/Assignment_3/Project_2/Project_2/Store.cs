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

            // Save the timestamp for the order
            DateTime orderTimestamp = DateTime.Now;

            // Encode the order object into a string
            Encoder encoder = new Encoder();
            string encodedOrder = encoder.Encode(order);

            // Send the order to the multi-cell buffer
            MultiCellBuffer.Instance.SetOneCell(encodedOrder);
        }

        // final confirmation callback, signalling that the order has been completed.
        public Action<double> confirmationCallback = totalAmount =>
        {
            // Calculate and print the order processing time
            DateTime processingTime = DateTime.Now;
            Console.WriteLine($"Store: Order processed in {processingTime} ms");
        };

        private int GenerateCreditCardNumber()
        {
            // Generate a random credit card number
            Random random = new Random();
            return random.Next(5000, 7001); // Including 7000
        }

        private int CalculateOrderQuantity(double currentPrice, double previousPrice)
        {
            // order calculation???? I feel like I did this wrong.
            return (int)(1000 / (currentPrice - previousPrice));
        }

    }
}
