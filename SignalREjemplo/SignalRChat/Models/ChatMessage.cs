using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRChat.Models
{
    public class ChatMessage
    {
        public string Autor {get; set;}
        public string Contenido { get; set; }

        public ChatMessage(string name, string msg)
        {
            // TODO: Complete member initialization
            Autor = name;
            Contenido = msg;
        }
    }
}
