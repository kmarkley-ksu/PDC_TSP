﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markley_PDC_Project_CSharp
{
    public class Tree
    {
        public TreeNode root;

        public Tree(int[] cities, int amount, int partialCost)
        {
            this.root = new TreeNode(cities, amount, partialCost);
        }
    }
}
