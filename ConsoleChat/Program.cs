using ConsoleChat.Net.IO;
using ConsoleChat.MVVM.ViewModel;
using ConsoleChat.Net;
using System;
using System.Collections.ObjectModel;

namespace ConsoleChat
{
    class Program
    {
        static void Main()
        {
            Console.Write("Sisesta nimi: ");
            string username = Console.ReadLine();

            Server server = new Server();
            MainViewModel _mainViewModel = new MainViewModel(username, server);

            Console.WriteLine("Sisesta sõnum (või kirjuta 'lahku', et lahkuda):");
            while (true)
            {
                string input = Console.ReadLine();

                if (input?.ToLower() == "lahku")
                {
                    break;
                }

                _mainViewModel.SendMessage(input);
                Console.WriteLine($"You: {input}");
            }
        }
    }
}
