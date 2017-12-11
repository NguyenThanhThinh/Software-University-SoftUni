namespace MVC.Framework.ViewEngine.Generic
{
    using System;
    using Contracts.Generic;

    public class ActionResul<TModel> : IActionResult<TModel>

    {
        public ActionResul(string viewFullQualifiedName, TModel model)
        {
            this.Action = (IRenderable<TModel>)Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));

            this.Action.Model = model;
        }

        public string Invoke()
        {
            throw new System.NotImplementedException();
        }

        public IRenderable<TModel> Action { get; set; }
    }
}