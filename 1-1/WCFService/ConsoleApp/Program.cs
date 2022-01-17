// Console app that connects to the service via proxy endpoints

// create instance of proxy service
serviceRef.ServiceClient myProxyService = new serviceRef.ServiceClient();

// defining some test variables
double pi = myProxyService.PiValue();
Int32 testVar1 = 27;
Int32 testVar2 = -144;
Int32 absVal1 = myProxyService.AbsValue(testVar1);
Int32 absVal2 = myProxyService.AbsValue(testVar2);

// Output some things
Console.WriteLine("PI Value = {0}", pi);
Console.WriteLine("Absolute values of {0} is {1}, and of {2} is {3}", testVar1, absVal1, testVar2, absVal2);
Console.WriteLine("GetData = {0}", myProxyService.GetData(1234));

myProxyService.Close();