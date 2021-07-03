using System.Collections.Generic;

namespace TestWorkForAlgoTecture.Parser
{
    public class ProductOccurence
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Prop> Props { get; set; }
    }
}
