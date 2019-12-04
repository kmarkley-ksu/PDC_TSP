using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markley_PDC_Project
{
    public class Tree
    {
        public Node root;

        public Tree(int[] cities, int amount, int partialCost)
        {
            this.root = new Node(cities, amount, partialCost);
        }
    }
}
