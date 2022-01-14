using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Net;
using System.Text;

// To use ServiceContract/ServiceModel, you need to install System.ServiceModel.Primitives
// IDE will let you do that by looking through the solutions.
// RUN THIS SERVICE IN ADMINISTRATOR MODE

// USE .NET FRAMEWORK 4.8 FOR FULL COMPATIBILITY
namespace ServiceConsole
{   
    [ServiceContract]
    public interface IMyInterface
    {
        [OperationContract] double PiValue();
        [OperationContract] int AbsValue(int val);
    }

    public class myService : IMyInterface
    {
        public int AbsValue(int val)
        {
            if(val >= 0)
            {
                return val;
            } else
            {
                return -val;
            }
        }

        public double PiValue() 
        {
            double pi = System.Math.PI;

            return pi;
        }
    }

    public class Program
    {
        static void Main(String[] args)
        {
            // First, we create the URI instance to myService; this address can be whatever we want
            Uri baseAddress = new Uri("http://localhost:8000/Service");

            // then we create a service host instance so our service can be hosted
            ServiceHost serviceHost = new ServiceHost(typeof(myService), baseAddress);

            // next, we add the binding. we will use WS Http as the protocol.
            serviceHost.AddServiceEndpoint(
                typeof(IMyInterface),
                new WSHttpBinding(),
                "myService"
            );

            // Then, add metadata. This lets us publicly access our service.
            System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();

            smb.HttpGetEnabled = true;

            serviceHost.Description.Behaviors.Add(smb);

            // start the service
            serviceHost.Open();

            Console.WriteLine("serviceHost ready to take requests. Create client to call PiValue() or AbsValue() methods. To quit, hit ENTER.");
               
            // ReadLine is used to keep process open
            Console.ReadLine();
            
            // close the service.
            serviceHost.Close();
        }
    }
}