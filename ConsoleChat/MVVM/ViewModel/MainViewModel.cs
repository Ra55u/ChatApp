using ConsoleChat.MVVM.Model;
using ConsoleChat.Net;
using System.Collections.ObjectModel;
using System.Windows;

namespace ConsoleChat.MVVM.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        public string Username { get; set; }
        private Server _server;

        public MainViewModel(string username, Server server)
        {
            Username = username;
            Users = new ObservableCollection<UserModel>();
            Messages = new ObservableCollection<string>();
            _server = server;
            _server.connectedEvent += UserConnected;
            _server.msgReceivedEvent += MessageReceived;
            _server.userDisconnectEvent += RemoveUser;
            _server.ConnectToServer(Username);
        }
        public void SendMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                _server.BroadcastMessage($"{Username}: {message}");
                Messages.Add($"{Username}: {message}");
            }
        }

        private void RemoveUser()
        {
            var uid = _server.PacketReader.ReadMessage();
            var user = Users.Where(x => x.UID == uid).FirstOrDefault();
            Users.Remove(user);
        }

        private void MessageReceived()
        {
            var msg = _server.PacketReader.ReadMessage();
            Messages.Add(msg);
        }

        private void UserConnected()
        {
            var user = new UserModel
            {
                Username = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage(),
            };

            if (!Users.Any(x => x.UID == user.UID))
            {
                Users.Add(user);
            }
        }
    }
}
