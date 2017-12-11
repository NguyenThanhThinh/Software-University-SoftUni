namespace MyCoolWebServer.GameStoreApplication
{
    using System;
    using System.Globalization;
    using Controllers;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Server.Routing;
    using ViewModels.Account;
    using ViewModels.Admin;

    class GameStoreApp
    {
        private const string Email = "email";
        private const string Password = "password";
        private const string AccountRegister = @"/account/register";
        private const string AccountLogin = @"/account/login";
        private const string HomeIndex = "/";
        private const string AdminAddGame = @"/admin/games/add";

        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(AppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add(HomeIndex);
            appRouteConfig.AnonymousPaths.Add(AccountRegister);
            appRouteConfig.AnonymousPaths.Add(AccountLogin);

            appRouteConfig
                .Get(HomeIndex, req => new HomeController(req).Index());

            appRouteConfig
                .Get(AccountRegister,
                 req => new AccountController(req).Register());

            appRouteConfig
                .Post(AccountRegister,
                req => new AccountController(req).Register(
                    new RegisterViewModel()
                    {
                        Email = req.FormData[Email],
                        FullName = req.FormData["full-name"],
                        Password = req.FormData[Password],
                        ConfirmPassword = req.FormData["confirm-password"]
                    }));

            appRouteConfig
                .Get(AccountLogin,
                req => new AccountController(req).Login());

            appRouteConfig
                .Post(AccountLogin,
                    req => new AccountController(req).Login(
                        new LoginViewModel()
                        {
                            Email = req.FormData[Email],
                            Password = req.FormData[Password]
                        }));

            appRouteConfig
                .Get("/account/logout",
                req => new AccountController(req).Logout());

            appRouteConfig
                .Get(AdminAddGame,
                req => new AdminController(req).Add());

            appRouteConfig
                .Post(AdminAddGame,
                    req => new AdminController(req).Add(new AdminAddGameViewModel()
                    {
                        Title = req.FormData["title"],
                        Description = req.FormData["description"],
                        Image = System.Text.Encoding.UTF8.GetBytes(req.FormData["image"]),
                        Price = decimal.Parse(req.FormData["price"]),
                        Size = double.Parse(req.FormData["size"]),
                        VideoId = req.FormData["youtube"],
                        ReleaseDate = DateTime.ParseExact(
                            req.FormData["release-date"],
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture)
                    }));

            appRouteConfig
                .Get("admin/games/list",
                req => new AdminController(req).List());
        }
    }
}