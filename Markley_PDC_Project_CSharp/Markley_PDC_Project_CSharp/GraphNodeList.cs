using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markley_PDC_Project_CSharp
{
    public class GraphNodeList<T> : NodeList<T>
    {
        public GraphNodeList() : base() { }

        public GraphNodeList(int initialSize) : base (initialSize) { }

        public new GraphNode<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (GraphNode<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
}
