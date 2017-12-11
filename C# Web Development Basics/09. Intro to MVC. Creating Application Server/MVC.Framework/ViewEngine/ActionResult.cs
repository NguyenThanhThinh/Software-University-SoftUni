﻿namespace MVC.Framework.ViewEngine
{
    using System;
    using Contracts;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifiedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke() => this.Action.Render();
    }
}