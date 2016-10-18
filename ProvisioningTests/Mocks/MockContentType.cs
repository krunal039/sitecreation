using System.Xml.Serialization;

namespace ProvisioningTests.Mocks
{
    public class MockContentType
    {
        [XmlAttribute]
        public string ID { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool IsDefault { get; set; }
    }
}