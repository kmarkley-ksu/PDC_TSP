using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Markley_PDC_Project_CSharp
{
    /*
    The leaves of the tree correspond to tours, 
    and the other tree nodes correspond to “partial” tours—routes that have visited some, but not all, of the cities.

    Each node of the tree has an associated cost, that is, the cost of the partial tour.

    We can use this to eliminate some nodes of the tree. 
    Thus, we want to keep track of the cost of the best tour so far,
    and, if we find a partial tour or node of the tree that couldn’t possibly lead to a less expensive complete tour, 
    we shouldn’t bother searching the children of that node (see Figures 6.9 and 6.10).
    */
    public class TreeNode
    {
        /*
        the array storing the cities, 
        the number of cities, 
        and the cost of the partial tour.
        */
        public int[] cities;            //Cities that have already been visited.
        public int amountOfCities;      //The amount of cities that have been visisted already.
        public int partialTourCost;     //The cost of the tour of visisted cit

        public List<TreeNode> children;  //List of potential next cities to visit.

        public TreeNode(int[] cities, int amount, int partialCost)
        {
            this.cities = cities;
            this.amountOfCities = amount;
            this.partialTourCost = partialCost;

            this.children = new List<TreeNode>();
        }
    }
}
