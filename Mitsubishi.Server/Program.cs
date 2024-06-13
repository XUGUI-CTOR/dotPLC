using dotPLC.Mitsubishi;

public class Program
{
    static void Main(string[] args)
    {
        SLMPServer sLMPServer = new SLMPServer();
        sLMPServer.Start();
        Console.ReadKey();
    }
}