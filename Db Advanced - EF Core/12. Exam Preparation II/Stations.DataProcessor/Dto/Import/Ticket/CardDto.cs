namespace Stations.DataProcessor.Dto.Import.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public class CardDto
    {
        [XmlAttribute("Name")]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}