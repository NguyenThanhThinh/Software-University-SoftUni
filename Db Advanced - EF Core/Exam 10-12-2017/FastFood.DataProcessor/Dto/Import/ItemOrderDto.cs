namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Item")]
    public class ItemOrderDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}