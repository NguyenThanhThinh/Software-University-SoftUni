namespace FastFood.DataProcessor.Dto.Export.Employee
{
    using System.Collections.Generic;

    public class OrderItemsDto
    {
        public string Customer { get; set; }

        public List<ItemDto> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}