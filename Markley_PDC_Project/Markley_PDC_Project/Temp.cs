using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markley_PDC_Project
{
    class Temp
    {
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
        void depth_first_search(Node tour)
        {
            int city;

            if (city_count(tour) == TOTAL_AMOUNT_OF_CITIES)
            {
                //If there are the total amount of cities in the tour so far, we know that we simply need to return to the hometown to complete the tour.
                if (best_tour(tour))
                {
                    //If the tour has a lower cost than our current best tour does, we can replace the current best tour with this tour by calling the function update_best_tour.
                    update_best_tour(tour);
                }
            }
            //If the partial tour tour hasn’t visited n cities, we can continue branching down in the tree by “expanding the current node,”
            //in other words, by trying to visit other cities from the city last visited in the partial tour.
            else
            {
                //To do this we simply loop through the cities.
                //for each neighboring city
                foreach (int nextCity in city.cities)
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
    }
}
