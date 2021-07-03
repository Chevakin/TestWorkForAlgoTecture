using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TestWorkForAlgoTecture.Parser
{
    public class AlgoTectureXmlParser
    {
        private readonly XmlDocument _xml;

        public AlgoTectureXmlParser(XmlDocument xml)
        {
            if (xml is null)
            {
                throw new ArgumentNullException(nameof(xml));
            }

            _xml = xml;
        }

        public IEnumerable<ProductOccurence> Parse()
        {
            using var ProductOccurences = _xml.GetElementsByTagName("ProductOccurence");
            {
                return ParseProductOccurencesNodes(ProductOccurences).ToArray();
            }
        }

        private IEnumerable<ProductOccurence> ParseProductOccurencesNodes(XmlNodeList nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            var productOccurences = new ProductOccurence[nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                productOccurences[i] = ParseProductOccurenceNode(nodes[i]);
            }

            return productOccurences;
        }

        private ProductOccurence ParseProductOccurenceNode(XmlNode node)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            var product = new ProductOccurence
            {
                Name = node.Attributes.GetNamedItem("Name").Value,
                Id = node.Attributes.GetNamedItem("Id").Value,
            };

            product.Props = ParseAttributeNode(node.ChildNodes);

            return product;
        }

        private IEnumerable<Prop> ParseAttributeNode(XmlNodeList nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            var attributes = GetAtributes(nodes);

            var props = new Prop[attributes.Count];

            for (int i = 0; i < attributes.Count; i++)
            {
                props[i] = ParseAtributeNode(attributes[i]);
            }

            return props;
        }

        private XmlNodeList GetAtributes(XmlNodeList nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            XmlNode node;

            for (int i = 0; i < nodes.Count; i++)
            {
                node = nodes[i];

                if (node.Name == "Attributes")
                {
                    return node.ChildNodes;
                }
            }

            return new XmlDocument().ChildNodes;
        }

        private Prop ParseAtributeNode(XmlNode node)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            var prop = new Prop
            {
                Name = node.Attributes.GetNamedItem("Name").Value,
                Type = node.Attributes.GetNamedItem("Type").Value,
                Value = node.Attributes.GetNamedItem("Value").Value
            };

            return prop;
        }
    } 
}
