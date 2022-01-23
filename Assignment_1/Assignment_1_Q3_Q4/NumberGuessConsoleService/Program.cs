using System;
using System.ServiceModel;

namespace NumberGuessConsoleService
{
    [ServiceContract]
    public interface INumberGuess
    {
        [OperationContract]
        int SecretNumber(int upper, int lower);
        [OperationContract]
        string CheckNumber(int userNum, int secretNum);
    }

    /*
     * Class of our number guessing name, implements our interface above.
     */
    public class NumberGuess : INumberGuess
    {
        public string CheckNumber(int userNum, int secretNum)
        {
            if (userNum == secretNum)
                return "correct";
            else
            if (userNum > secretNum)
                return "too big";
            else return "too small";
        }

        public int SecretNumber(int lower, int upper)
        {
            DateTime currentDate = DateTime.Now;
            int seed = (int)currentDate.Ticks;
            Random random = new Random(seed);
            int sNumber = random.Next(lower, upper);
            return sNumber;
        }
    }

    /*
     * Main console program, runs and executes hosting code and exposes port/endpoint at
     * localhost:8000/Service
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            // First, we create the URI instance to myService; this address can be whatever we want
            Uri baseAddress = new Uri("http://localhost:8000/Service");

            // then we create a service host instance so our service can be hosted
            ServiceHost serviceHost = new ServiceHost(typeof(NumberGuess), baseAddress);

            // next, we add the binding. we will use WS Http as the protocol.
            serviceHost.AddServiceEndpoint(
                typeof(INumberGuess),
                new WSHttpBinding(),
                "NumberGuess"
            );

            // Then, add metadata. This lets us publicly access our service.
            System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();

            smb.HttpGetEnabled = true;

            serviceHost.Description.Behaviors.Add(smb);

            // start the service
            serviceHost.Open();

            Console.WriteLine("Server running on http://localhost:8000/Service");
            Console.WriteLine("Number Guess Service is ready to take requests. Hit ENTER to quit.");

            // ReadLine is used to keep process open
            Console.ReadLine();

            // close the service.
            serviceHost.Close();
        }
    }
}
