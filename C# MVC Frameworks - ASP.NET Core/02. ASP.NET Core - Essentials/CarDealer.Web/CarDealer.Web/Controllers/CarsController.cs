namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.Models.Cars;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IPartService partService;

        public CarsController(ICarService carService, IPartService partService)
        {
            this.carService = carService;
            this.partService = partService;
        }

        [Route("{make}")]
        public IActionResult ByMake(string make)
        {
            var cars = this.carService.CarsInfo(make);

            return this.View(cars);
        }

        [Route(nameof(CarsWithParts))]
        public IActionResult CarsWithParts()
        {
            var carAndParts = this.carService.CarWithPartsInfo();

            return this.View(carAndParts);
        }

        [Route(nameof(Add))]
        public IActionResult Add()
        {
            var parts = this.partService.AllPartNamesAndPrices();

            var carWithParts = new AddCarWithPartsModel
            {
                Parts = parts
            };

            return this.View(carWithParts);
        }

        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(AddCarWithPartsModel carWithParts)
        {
            if (!this.ModelState.IsValid)
            {
                return this.NotFound();
            }

            this.carService.AddCarWithParts(carWithParts);

            return this.RedirectToAction("CarsWithParts");
        }
    }
}