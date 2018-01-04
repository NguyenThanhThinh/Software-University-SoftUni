namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.Models;
    using Services.Models.Parts;

    [Route("parts")]
    public class PartsController : Controller
    {
        private readonly IPartService partService;

        public PartsController(IPartService partService)
        {
            this.partService = partService;
        }

        [Route(nameof(AddPart))]
        public IActionResult AddPart()
            => this.View();

        [HttpPost]
        [Route(nameof(AddPart) + "/{name}/{price}/{supplier}/{quantity}")]
        public IActionResult AddPart(string name, double price, string supplier, int quantity)
        {
            var addPartSuccess = this.partService.AddPart(name, price, supplier, quantity);

            if (addPartSuccess)
            {
                return this.View();
            }

            return this.NotFound();
        }

        [Route(nameof(All))]
        public IActionResult All()
            => this.View(this.partService.All());

        [HttpPost]
        [Route(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var isDeleted = this.partService.DeletePart(id);

            if (!isDeleted)
            {
                return this.NotFound();
            }

            return this.RedirectToAction(nameof(this.All));
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
            => this.View(this.partService.GetById(id));

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, PartEditModel part)
        {
            if (!this.ModelState.IsValid)
            {
                return this.NotFound();
            }

            this.partService.EditPart(id,
                part.Price,
                part.Quantity);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}