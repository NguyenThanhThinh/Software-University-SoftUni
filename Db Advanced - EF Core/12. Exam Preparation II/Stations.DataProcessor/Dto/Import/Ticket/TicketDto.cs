namespace Stations.DataProcessor.Dto.Import.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class TicketDto
    {
        [XmlAttribute("price")]
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlAttribute("seat")]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        [Required]
        public string Seat { get; set; }

        [XmlElement("Trip")]
        [Required]
        public TripDto Trip { get; set; }

        [XmlElement("Card")]
        public CardDto Card { get; set; }
    }
}