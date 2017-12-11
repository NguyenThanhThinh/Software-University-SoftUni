namespace Stations.DataProcessor.Dto.Export
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Import.Ticket;

    [XmlType("Card")]
    public class CardTicketDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        public List<TicketDto> Tickets { get; set; }
    }
}