// start of program
// services were generated from this command
// svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/Service

// create a proxy to the WCF service
MyInterfaceClient myProxy = new MyInterfaceClient();

// call service operations through the proxy
double pi = myProxy.PiValue();

Int32 val1 = 32;
Int32 val2 = -127;

// call our proxy functions
Int32 result1 = myProxy.AbsValue(val1);
Int32 result2 = myProxy.AbsValue(val2);

Console.WriteLine("Pi Value = {0}", pi);
Console.WriteLine("Absolute value of {0} is {1}, and of {2} is {3}", val1, result1, val2, result2);

myProxy.Close();

Console.WriteLine("/n Press ENTER to terminate the client");
Console.ReadLine();