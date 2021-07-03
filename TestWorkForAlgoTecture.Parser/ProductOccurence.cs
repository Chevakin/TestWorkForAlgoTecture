using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkForAlgoTecture.Parser
{
    [Serializable]
    public class ProductOccurence
    {
        public string Id;

        public string Name;

        public IEnumerable<Prop> Props;
    }
}
