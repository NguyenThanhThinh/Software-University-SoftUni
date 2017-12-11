namespace FastFood.DataProcessor.Dto.Export.Category
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        public MostPopularItemDto MostPopularItem { get; set; }
    }
}