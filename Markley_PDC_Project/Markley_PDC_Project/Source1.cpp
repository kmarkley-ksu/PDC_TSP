const int TOTAL_AMOUNT_OF_CITIES = 4;	//The total amount of cities.
/*
the array storing the cities, 
the number of cities, 
and the cost of the partial tour.
*/
struct tour_t
{
	int cities[TOTAL_AMOUNT_OF_CITIES];
	int amountOfCities;
	int partialTourCost;
};

struct tour_t bestTour;		//Making it a global variable so that it can be used across all the functions.

/*
To improve the readability and the performance of the code, we can use preprocessor
macros to access the members of the struct. However, since macros can be
a nightmare to debug, it’s a good idea to write “accessor” functions for use during
initial development. When the program with accessor functions is working, they can
be replaced with macros. As an example, we might start with the function
*/
/* Find the ith city on the partial tour */
//int tour_city(tour_t tour, int i)
//{
//	return tour->cities[i];
//}
//Replace with #define Tour_city(tour, i) (tour->cities[i])
/* Tour city */

//void Push(my_stack_t stack, int city)
//{
//	int loc = stack->list_sz;
//	stack->list[loc] = city;
//	stack->list_sz++;
//}/* Push */


/*
The function city_count examines the partial tour, tour, to see if there are TOTAL_AMOUNT_OF_CITIES
cities on the partial tour.
*/
bool city_count(tour_t tour)
{
	if(tour.amountOfCities == TOTAL_AMOUNT_OF_CITIES)
		return true;
	else
		return false;
}

/*
we can check to see if the complete tour has a
lower cost than the current “best tour” by calling Best tour
*/
bool best_tour(tour_t tour)
{
	if(tour.partialTourCost < bestTour.partialTourCost)
		return true;
	else
		return false;
}

/*
The function feasible checks to see if the city or vertex has already
been visited, and, if not, whether it can possibly lead to a least-cost tour.
*/
bool feasible(tour_t tour)
{

}


/*
n: total number of cities in the tour.
digraph: a data structure representing the input digraph.
hometown: a data structure representing vertex or city 0, the salesperson’shometown.
best_tour: a data structure representing the best tour so far.

*/
void depth_first_search(tour_t tour)
{
	city_t city;
	
	if (city_count(tour) == n)
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
		for each neighboring city
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

int _tmain(int argc, _TCHAR* argv[])
{
	bestTour.amountOfCities;

	return 0;

	//Note: that before the first call to Depth first search, 
	//the best tour variable should be initialized so that its cost is greater than the cost of any possible least-cost tour.
}