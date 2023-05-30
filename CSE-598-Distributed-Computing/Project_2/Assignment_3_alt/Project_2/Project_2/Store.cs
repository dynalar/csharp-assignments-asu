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
        private readonly string name;
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

            // Encode the order object into a string
            Encoder encoder = new Encoder();
            string encodedOrder = encoder.Encode(order);

            // Send the order to the multi-cell buffer
            MultiCellBuffer.Instance.SetOneCell(encodedOrder);

            // Save the timestamp for the order
            DateTime orderTimestamp = DateTime.Now;

            // Define the confirmation callback method
            Action<double> confirmationCallback = totalAmount =>
            {
                // Calculate and print the order processing time
                TimeSpan processingTime = DateTime.Now - orderTimestamp;
                Console.WriteLine($"Store: {name} - Order processed in {processingTime.TotalMilliseconds}ms");
            };

            // Start a new thread to process the order
            // THIS SHOULD BE DONE FROM THE COMPUTER MAKER INSTEAD NOT HERE
            OrderProcessing orderProcessing = new OrderProcessing();
            Thread orderProcessingThread = new Thread(() => orderProcessing.ProcessOrder(order, currentPrice));
            orderProcessingThread.Start();

            // Set the confirmation callback for the order
            order.ConfirmationCallback = confirmationCallback;
        }

        private int GenerateCreditCardNumber()
        {
            // Generate a random credit card number
            Random random = new Random();
            return random.Next(5000, 7001); // Including 7000
        }

        private int CalculateOrderQuantity(double currentPrice, double previousPrice)
        {
            // Implement your order quantity calculation logic here
            // This is just a placeholder
            return (int)(1000 / (currentPrice - previousPrice));
        }
    }
}
