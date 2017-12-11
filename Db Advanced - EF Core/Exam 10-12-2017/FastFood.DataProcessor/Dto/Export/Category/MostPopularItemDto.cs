namespace FastFood.DataProcessor.Dto.Export.Category
{
    using System.Xml.Serialization;

    [XmlType("MostPopularItem")]
    public class MostPopularItemDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("TotalMade")]
        public string TotalMade { get; set; }

        [XmlElement("TimesSold")]
        public int TimesSold { get; set; }
    }
}