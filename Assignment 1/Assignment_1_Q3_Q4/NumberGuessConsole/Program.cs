using System;

namespace NumberGuessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // game state variables
            int attempts = 0;
            bool gameEnd = false;
            

            // instantiate new proxy to our service
            NumberGuessClient NumberGuessProxy = new NumberGuessClient();

            // prompt user for initial values for lower/upper limit bounds
            Console.WriteLine("Welcome to the number guessing game!");

            Console.Write("Please enter a lower limit: ");
            int lowerLimit = int.Parse(Console.ReadLine());

            Console.Write("Please enter an upper limit: ");
            int upperLimit = int.Parse(Console.ReadLine());

            // generate the secret number by calling the proxy
            int secretNumber = NumberGuessProxy.SecretNumber(upperLimit, lowerLimit);

            // another space for formatting
            Console.WriteLine();
              
            // keep loop running until user selects the correct number.
            while(gameEnd == false)
            {
                Console.WriteLine("Total Attempts: " + attempts);
                Console.Write("Please guess the secret number: ");

                int guessedNumber = int.Parse(Console.ReadLine());

                string message = NumberGuessProxy.CheckNumber(guessedNumber, secretNumber);
                attempts++;

                Console.WriteLine(message + "\n");

                // End the 
                if(message == "correct")
                {
                    gameEnd = true;
                }
            }

            // only reach the state once the player wins the game.
            Console.WriteLine("You won! Press ENTER to quit the game.");
            Console.ReadLine();
        }
    }
}
