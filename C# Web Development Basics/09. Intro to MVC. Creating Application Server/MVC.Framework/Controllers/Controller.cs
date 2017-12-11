namespace MVC.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using Contracts;
    using Contracts.Generic;
    using Helpers;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName]string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controllerName, caller);

            return new ActionResult(viewFullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controller, action);

            return new ActionResult(viewFullQualifiedName);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName]string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controllerName, caller);

            return new ActionResul<TModel>(viewFullQualifiedName, model);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, string controller, string action)
        {
            string viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controller, action);

            return new ActionResul<TModel>(viewFullQualifiedName, model);
        }
    }
}