using log4net;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTunes.Filters
{
    public class LogginAction : ActionFilterAttribute
    {
        [Inject]
        public ILog Logger { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Logger.DebugFormat(
                "La Action que se ejecuto fue {0} {1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName);
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.DebugFormat(
                "La Action que se ejecuto fue {0} {1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName);
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Logger.DebugFormat(
                "El resultado fue {0}",
                filterContext.Result.ToString());
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Logger.DebugFormat(
                "El resultado fue {0}",
                filterContext.Result.ToString());
            base.OnResultExecuting(filterContext);
        }
    }
}