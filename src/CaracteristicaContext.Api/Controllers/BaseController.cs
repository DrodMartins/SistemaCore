using Core.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CaracteristicaContext.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        private readonly NotificationHandle _notifications;

        public BaseController(INotificationHandler<NotificationDomain> notifications)
        {
            _notifications = (NotificationHandle)notifications;
        }

        protected IActionResult Retorno(object result = null)
        {
            if (ExisteErro) return RetornoErro(_notifications.GetNotifications().Select(n => n.Valor));

            return RetornoSucesso(result);
        }

        private IActionResult RetornoSucesso(object result = null) => Ok(new { sucess = true, data = result });

        private IActionResult RetornoErro(object result = null) => BadRequest(new { sucess = false, erros = result });
        
        private bool ExisteErro => _notifications.HasNotifications();
    }
}