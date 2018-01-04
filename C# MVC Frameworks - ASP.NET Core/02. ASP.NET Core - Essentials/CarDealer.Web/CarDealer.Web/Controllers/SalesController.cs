namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Contracts;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService saleService;

        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var sales = this.saleService.Index();

            return this.View("Sales", sales);
        }

        [Route("{id}")]
        public IActionResult Index(int id)
        {
            var sale = this.saleService.Index(id);

            return this.View("Sales", sale);
        }

        [Route(nameof(Discounted))]
        public IActionResult Discounted()
        {
            var sales = this.saleService.Discounted();

            return this.View("Sales", sales);
        }

        [Route(nameof(Discounted) + "/{percentage}")]
        public IActionResult Discounted(double percentage)
        {
            var sales = this.saleService.Discounted(percentage);

            return this.View("Sales", sales);
        }
    }
}