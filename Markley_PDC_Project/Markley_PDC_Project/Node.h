#pragma once

#include "stdafx.h"
#include <iostream>

/*
The leaves of the tree correspond to tours, 
and the other tree nodes correspond to “partial” tours—routes that have visited some, but not all, of the cities.

Each node of the tree has an associated cost, that is, the cost of the partial tour.

We can use this to eliminate some nodes of the tree. 
Thus, we want to keep track of the cost of the best tour so far,
and, if we find a partial tour or node of the tree that couldn’t possibly lead to a less expensive complete tour, 
we shouldn’t bother searching the children of that node (see Figures 6.9 and 6.10).
*/
class Node
{
public:
	/*
	the array storing the cities, 
	the number of cities, 
	and the cost of the partial tour.
	*/
	int* cities;
	int amountOfCities;
	int partialTourCost;

	Node* next;

	Node(void);
	Node(int* visitedCities, int amountOfVisistedCities, int costOfCurrentTour);
	~Node(void);
};

