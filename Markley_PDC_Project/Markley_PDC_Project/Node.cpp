#include "Node.h"


Node::Node(void)
{
}

Node::Node(int* visitedCities, int amountOfVisistedCities, int costOfCurrentTour)
{
	this->cities = visitedCities;
	this->amountOfCities = amountOfVisistedCities;
	this->partialTourCost = costOfCurrentTour;

	std::cout << "Printing the route: " << *(visitedCities) << std::endl;
}

Node::~Node(void)
{
}
