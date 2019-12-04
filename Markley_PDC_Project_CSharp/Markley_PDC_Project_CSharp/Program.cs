using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markley_PDC_Project_CSharp
{
    class Program
    {
        //Note: that before the first call to Depth first search, 
        //the best tour variable should be initialized so that its cost is greater than the cost of any possible least-cost tour.
        //static TreeNode bestTour = new TreeNode(new int[] { 0, 1, 2, 3, 4 }, 5, 10000000);

        const int TOTAL_AMOUNT_OF_CITIES = 4;


        ///*
        //The function city_count examines the partial tour, tour, to see if there are TOTAL_AMOUNT_OF_CITIES
        //cities on the partial tour.
        //*/
        //static bool city_count(TreeNode tour)
        //{
        //    if (tour.amountOfCities == TOTAL_AMOUNT_OF_CITIES)
        //        return true;
        //    else
        //        return false;
        //}

        ///*
        //we can check to see if the complete tour has a
        //lower cost than the current “best tour” by calling Best tour
        //*/
        //static bool best_tour(TreeNode tour)
        //{
        //    if (tour.partialTourCost < bestTour.partialTourCost)
        //        return true;
        //    else
        //        return false;
        //}

        ///*
        //The function feasible checks to see if the city or vertex has already
        //been visited, and, if not, whether it can possibly lead to a least-cost tour.
        //*/
        //static bool feasible(TreeNode tour)
        //{
        //    return true;
        //}

        ////Updates the best tour global variable.
        //void update_best_tour(TreeNode tour)
        //{
        //    bestTour = tour;
        //}

        ////Adds the city to a tour.
        //void add_city(TreeNode tour, int city)
        //{

        //}

        ////Removes the last city from the tour.
        //void remove_last_city(TreeNode tour, int city)
        //{

        //}

        ///*
        //n: total number of cities in the tour.
        //digraph: a data structure representing the input digraph.
        //hometown: a data structure representing vertex or city 0, the salesperson’shometown.
        //best_tour: a data structure representing the best tour so far.
        //*/
        //static void depth_first_search(TreeNode tour)
        //{
        //    int city;

        //    if (tour.amountOfCities == TOTAL_AMOUNT_OF_CITIES)
        //    {
        //        //If there are the total amount of cities in the tour so far, we know that we simply need to return to the hometown to complete the tour.
        //        if (tour.partialTourCost < bestTour.partialTourCost)
        //        {
        //            //If the tour has a lower cost than our current best tour does, we can replace the current best tour with this tour by calling the function update_best_tour.
        //            bestTour = tour;
        //        }
        //    }
        //    //If the partial tour tour hasn’t visited n cities, we can continue branching down in the tree by “expanding the current node,”
        //    //in other words, by trying to visit other cities from the city last visited in the partial tour.
        //    else
        //    {
        //        ////To do this we simply loop through the cities.
        //        ////for each neighboring city
        //        //foreach(int nextCity in city.cities)
        //        //{
        //        //    if (feasible(tour, city))
        //        //    {
        //        //        //If the city is feasible, we add it to the tour, and recursively call depth first search.
        //        //        add_city(tour, city);
        //        //        depth_first_search(tour);

        //        //        //When we return from Depth first search, we remove the city from the tour, 
        //        //        //since it shouldn’t be included in the tour used in subsequent recursive calls.
        //        //        remove_last_city(tour, city);
        //        //    }
        //        //}
        //    }
        //}
        ///* Depth first search */

        static void Main(string[] args)
        {
            Graph<Int32> cities = new Graph<Int32>();

            cities.AddNode(0);
            cities.AddNode(1);
            cities.AddNode(2);
            cities.AddNode(3);

            cities.AddDirectedEdge(0, 1, 1);  // 0 -> 1, 1
            cities.AddDirectedEdge(0, 2, 3);  // 0 -> 2, 3
            cities.AddDirectedEdge(0, 3, 8);  // 0 -> 3, 8

            cities.AddDirectedEdge(1, 0, 5);  // 1 -> 0, 5
            cities.AddDirectedEdge(1, 2, 2);  // 1 -> 2, 2
            cities.AddDirectedEdge(1, 3, 6);  // 1 -> 3, 6

            cities.AddDirectedEdge(2, 0, 1);    // 2 -> 0, 1
            cities.AddDirectedEdge(2, 1, 18);   // 2 -> 0, 18
            cities.AddDirectedEdge(2, 3, 10);   // 2 -> 0, 10

            cities.AddDirectedEdge(3, 0, 7);    // 3 -> 0, 7
            cities.AddDirectedEdge(3, 1, 4);    // 3 -> 0, 4
            cities.AddDirectedEdge(3, 2, 12);   // 3 -> 0, 12

            //Printing out the entire city graph in this loop.
            int i = 0;
            Console.WriteLine("City Graph: ");
            foreach (GraphNode<Int32> city in cities.Nodes)
            {
                //int currentCityAmount = gNode.Neighbors.Count;
                //Console.WriteLine("Amount of cities in this partial tour: " + currentCityAmount);

                Console.Write("City " + city.Value + " is connected to: ");
                //Console.WriteLine("Neighbors for " + gNode.Value);

                //Console.WriteLine("Amount of neighbors: " + gNode.Neighbors.Count);

                foreach (GraphNode<Int32> neighbor in city.Neighbors)
                {
                    //Console.Write("|| " + neighbor.Value + " || ");
                    Console.Write(" || " + city.Value + " -> " + neighbor.Value + " with a cost of : " + city.Costs[i]);

                    i++;
                }
                i = 0;
                Console.WriteLine();
            }
        }
    }
}