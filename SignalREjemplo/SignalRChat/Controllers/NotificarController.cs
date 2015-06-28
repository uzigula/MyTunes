using SignalRChat.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class NotificarController : Controller
    {
        // GET: Notificar
        [HttpPost]
        public void Publicar(string message)
        {
            new ChatNotifier().EnviarNotificacion(message);
        }
    }
}