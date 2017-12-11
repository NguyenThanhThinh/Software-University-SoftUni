﻿namespace SimpleMvc.App.Views.User
{
    using System.Text;
    using MVC.Framework.Contracts;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h3>Register new user</h3>");
            sb.AppendLine(@"<form action=""register"" method=""POST""><br />");
            sb.AppendLine(@"Username: <input type=""text"" name=""Username""/><br />");
            sb.AppendLine(@"Password <input type=""password"" name=""Password""/><br />");
            sb.AppendLine(@"<input type=""submit"" value=""Register""");
            sb.AppendLine(@"</form><br />");

            return sb.ToString();
        }
    }
}