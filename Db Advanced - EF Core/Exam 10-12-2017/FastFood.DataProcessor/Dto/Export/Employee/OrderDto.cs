namespace FastFood.DataProcessor.Dto.Export.Employee
{
    using System.Collections.Generic;

    public class OrderDto
    {
        public string Name { get; set; }

        public List<OrderItemsDto> Orders { get; set; }

        public decimal TotalMade { get; set; }
    }
}