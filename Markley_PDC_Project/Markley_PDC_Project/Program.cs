using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markley_PDC_Project
{
    class Program
    {
        //Note: that before the first call to Depth first search, 
        //the best tour variable should be initialized so that its cost is greater than the cost of any possible least-cost tour.
        static Node bestTour = new Node(new int[] { 0, 1, 2, 3, 4 }, 5, 10000000);

        const int TOTAL_AMOUNT_OF_CITIES = 4;


        /*
        The function city_count examines the partial tour, tour, to see if there are TOTAL_AMOUNT_OF_CITIES
        cities on the partial tour.
        */
        static bool city_count(Node tour)
        {
            if (tour.amountOfCities == TOTAL_AMOUNT_OF_CITIES)
                return true;
            else
                return false;
        }

        /*
        we can check to see if the complete tour has a
        lower cost than the current “best tour” by calling Best tour
        */
        static bool best_tour(Node tour)
        {
            if (tour.partialTourCost < bestTour.partialTourCost)
                return true;
            else
                return false;
        }

        /*
        The function feasible checks to see if the city or vertex has already
        been visited, and, if not, whether it can possibly lead to a least-cost tour.
        */
        static bool feasible(Node tour)
        {

        }

        //Updates the best tour global variable.
        void update_best_tour(Node tour)
        {
            bestTour = tour;
        }

        //Adds the city to a tour.
        void add_city(Node tour, Node city)
        {

        }

        //Removes the last city from the tour.
        void remove_last_city(Node tour, Node city)
        {

        }

        /*
        n: total number of cities in the tour.
        digraph: a data structure representing the input digraph.
        hometown: a data structure representing vertex or city 0, the salesperson’shometown.
        best_tour: a data structure representing the best tour so far.
        */
        static void depth_first_search(Node tour)
        {
            int city;

            if (tour.amountOfCities == TOTAL_AMOUNT_OF_CITIES)
            {
                //If there are the total amount of cities in the tour so far, we know that we simply need to return to the hometown to complete the tour.
                if (tour.partialTourCost < bestTour.partialTourCost)
                {
                    //If the tour has a lower cost than our current best tour does, we can replace the current best tour with this tour by calling the function update_best_tour.
                    bestTour = tour;
                }
            }
            //If the partial tour tour hasn’t visited n cities, we can continue branching down in the tree by “expanding the current node,”
            //in other words, by trying to visit other cities from the city last visited in the partial tour.
            else
            {
                //To do this we simply loop through the cities.
                //for each neighboring city
                foreach(int nextCity in city.cities)
                {
                    if (feasible(tour, city))
                    {
                        //If the city is feasible, we add it to the tour, and recursively call depth first search.
                        add_city(tour, city);
                        depth_first_search(tour);

                        //When we return from Depth first search, we remove the city from the tour, 
                        //since it shouldn’t be included in the tour used in subsequent recursive calls.
                        remove_last_city(tour, city);
                    }
                }
            }
        }
        /* Depth first search */

        static void Main(string[] args)
        {
            int[] cities = { 0 };
            int amount = 1;
            int cost = 0;

            Tree possibleTours = new Tree(cities, amount, cost)

            //for(int i = 1; i < 4; i++)
            //{
            //    cities = new int[] { 0, 1 };
            //    amount = 2;
            //    cost = 1;

            //    possibleTours.root.next = new Node(cities, amount, cost);
            //}

            //Printing out the entire tree loop.
            Node current = possibleTours.root;

            for (int i = 0; i < 2; i++)
            {
                int currentCityAmount = current.amountOfCities;
                Console.WriteLine("Amount of cities in this partial tour: " + currentCityAmount + " and cost of this tour: " + current.partialTourCost);

                Console.Write("Route (left to right): ");

                for (int cityAmount = 0; cityAmount < currentCityAmount; cityAmount++)
                {
                    if (cityAmount == currentCityAmount - 1)
                    {
                        Console.Write(current.cities[cityAmount]);
                    }
                    else
                    {
                        Console.Write(current.cities[cityAmount] + " -> ");
                    }
                }

                Console.WriteLine();

                current = current.next;
            }
        }
    }
}
