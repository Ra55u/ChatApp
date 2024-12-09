using System;
using System.Net.Sockets;

namespace ConsoleChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverHost = Environment.GetEnvironmentVariable("SERVER_HOST") ?? "localhost";
            int port = 7891;

            Console.WriteLine($"Connecting to server at {serverHost}:{port}...");

            try
            {
                using (TcpClient client = new TcpClient(serverHost, port))
                {
                    Console.WriteLine("Connected to the server.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to server: {ex.Message}");
            }
        }
    }
}
