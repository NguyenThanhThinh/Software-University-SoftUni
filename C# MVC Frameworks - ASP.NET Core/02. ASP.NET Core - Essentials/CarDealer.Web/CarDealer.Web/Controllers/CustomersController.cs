namespace CarDealer.Web.Controllers
{
    using App.Models.Customers;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.Models;
    using Services.Models.Customers;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route(nameof(All) + "/{orderBy?}")]
        public IActionResult All(string orderBy)
        {
            OrderType orderType =
                orderBy == "descending" ?
                    OrderType.Descending :
                    OrderType.Ascending;

            var customers = this.customerService.OrderCustomers(orderType);

            var result = new AllCustomersModel
            {
                Customers = customers,
                OrderType = orderType
            };

            return this.View(result);
        }

        [Route("{id}")]
        public IActionResult Index(int id)
        {
            var customerById = this.customerService.CustomerById(id);

            return this.View("CustomerTotalSales", customerById);
        }

        [Route(nameof(Add))]
        public IActionResult Add()
            => this.View();

        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(CustomerModel customer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.customerService.Add(
                customer.Name,
                customer.Birthday);

            return this.RedirectToAction(nameof(this.All));
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customerService.CustomerToEdit(id);

            return this.View(customer);
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, CustomerModel customer)
        {
            this.customerService.Edit(
                id,
                customer.Name,
                customer.Birthday);

            return this.RedirectToAction("All");
        }
    }
}