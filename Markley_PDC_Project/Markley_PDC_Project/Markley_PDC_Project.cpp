// Markley_PDC_Project.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "Tree.h"
#include <vector>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	cout << "Hello World!" << endl;

	Tree possibleTours = Tree();

	vector<int> city = {0};

	int* cities = new int{0};
	int amount = 1;
	int cost = 0;

	cout << *(cities) << endl;

	possibleTours.root = new Node(cities, amount, cost);

	int cities[] = {0, 1};
	amount = 2;
	cost = 1;

	possibleTours.root->next = new Node(cities, amount, cost);

	Node* current = possibleTours.root;

	for(int i = 0; i < 2; i++)
	{
		int currentCityAmount = current->amountOfCities;
		cout << "Amount of cities in this partial tour: " << currentCityAmount << " and cost of this tour: " << current->partialTourCost << endl;

		cout << "Route (left to right): ";

		for(int cityAmount = 0; cityAmount < currentCityAmount; cityAmount++)
		{
			if(cityAmount == currentCityAmount - 1)
			{
				cout << *(current->cities + cityAmount);
			}
			else
			{
				cout << *(current->cities + cityAmount) << " -> ";
			}
		}

		cout << endl;

		current = current->next;
	}

	return 0;

	//Note: that before the first call to Depth first search, 
	//the best tour variable should be initialized so that its cost is greater than the cost of any possible least-cost tour.
}
