using System.IO;
using System.Text.Json;
using System.Xml;

namespace TestWorkForAlgoTecture.Parser
{
    public class Parser
    {
        public void Parse(string path)
        {
            var xml = GetXmlDocument();
            var xmlParser = new AlgoTectureXmlParser(xml);

            var products = xmlParser.Parse();
            using var file = File.OpenWrite(path);

            JsonSerializer.SerializeAsync(file, products);
        }

        private XmlDocument GetXmlDocument()
        {
            var xml = new XmlDocument();
            xml.Load("test.xml");

            return xml;
        }
    }
}
