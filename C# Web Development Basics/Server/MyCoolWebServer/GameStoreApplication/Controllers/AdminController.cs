namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using System;
    using System.Linq;
    using Server.Http.Contracts;
    using Services;
    using Services.Contracts;
    using ViewModels.Admin;

    public class AdminController : BaseController
    {
        private const string AddGameView = @"admin\add-game";
        private const string ListGameView = @"admin\list-games";

        private IGameService games;

        public AdminController(IHttpRequest request)
            : base(request)
        {
            this.games = new GameService();
        }

        public IHttpResponse Add()
        {
            if (this.Authentication.IsAdmin)
            {
                return this.FileViewResponse(AddGameView);
            }

            return this.RedirectResponse(HomeIndex);
        }

        public IHttpResponse Add(AdminAddGameViewModel model)
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomeIndex);
            }

            if (!this.ValidateModel(model))
            {
                return this.Add();
            }

            this.games.Create(
                model.Title,
                model.Description,
                model.Image,
                model.Price,
                model.Size,
                model.VideoId,
                model.ReleaseDate);

            return this.RedirectResponse("/admin/games/list");
        }

        public IHttpResponse List()
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomeIndex);
            }

            var result = this.games
                .All()
                .Select(g => $@"<tr><td>{g.Id}</td><td>{g.Name}</td><td>{g.Size:F2} GB</td><td>{g.Price:F2} &euro;</td><td>
                            <a class=""btn btn-warning"" href=""/admin/games/edit/{g.Id}"">Edit</a>
                            <a class=""btn btn-danger"" href=""/admin/games/delete/{g.Id}"">Delete</a></td></tr>");

            string gamesAsHtml = string.Join(Environment.NewLine, result);

            this.ViewData["games"] = gamesAsHtml;

            return this.FileViewResponse(ListGameView);
        }
    }
}