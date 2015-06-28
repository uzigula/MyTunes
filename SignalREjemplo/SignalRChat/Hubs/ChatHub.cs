using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalRChat.Models;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private static IDictionary<string, string> users = new Dictionary<string, string>();
        public override System.Threading.Tasks.Task OnConnected()
        {
            return base.OnConnected();
        }
        public void Send(string name, string msg, string grupo)
        {
            Clients.Group(grupo).showMessage(new ChatMessage(name, msg));
            //Clients.All.showMessage(new ChatMessage(name, msg));
        }

        public void Entrar(string name)
        {
            users.Add(new KeyValuePair<string, string>(name, this.Context.ConnectionId));
        }

        public void MensajePara(string Destino, string origen, string mensaje)
        {
            var destinoId = string.Empty;
            if (users.TryGetValue(Destino, out destinoId))
            {
                var client = Clients.Client(destinoId);
                client.showMessage(new ChatMessage(origen, mensaje));
            }
        }

        public void EntrarA(string grupo)
        {
            this.Groups.Add(this.Context.ConnectionId, grupo);
        }
    }
}