using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChat.Hubs;
using SignalRChat.Models;

namespace SignalRChat.Notifiers
{
    public class ChatNotifier
    {
        private IHubConnectionContext<dynamic> _clients;
        public ChatNotifier()
        {
            _clients = GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients;
        }

        public void EnviarNotificacion(string message)
        {
            _clients.All.showMessage(new ChatMessage("Moderador", message));
        }
  
    }
}