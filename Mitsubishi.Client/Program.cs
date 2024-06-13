using dotPLC.Mitsubishi;
using System.Net;

SLMPClient client = new SLMPClient("192.168.96.10", 4030);
client.Connect();
 var value = client.ReadDevice<float>("D4260");
Console.WriteLine(value);
Console.ReadKey();
