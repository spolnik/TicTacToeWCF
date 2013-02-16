
using System;
using System.ServiceModel;

namespace TicTacToeServer
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Tic-Tac-Toe Server...");

            var host = new ServiceHost(typeof(TicTacToeService.TicTacToeService));

            host.Open();
            Console.WriteLine("Server is started...");
            Console.WriteLine("Press [ENTER] to stop a server...");
            Console.ReadLine();

            if (host.State != CommunicationState.Closed)
                host.Close();


            Console.WriteLine("Server is stopped ...");
        }
    }
}
