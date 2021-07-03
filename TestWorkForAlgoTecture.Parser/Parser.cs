using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml;
using System.IO;

namespace TestWorkForAlgoTecture.Parser
{
    public class Parser
    {
        public void Parse()
        {
            var xml = GetxmlDocument();
            var xmlParser = new AlgoTectureXmlParser(xml);
        }

        private XmlDocument GetxmlDocument()
        {
            var xml = new XmlDocument();
            xml.Load("test.xml");

            return xml;
        }
    }
}
