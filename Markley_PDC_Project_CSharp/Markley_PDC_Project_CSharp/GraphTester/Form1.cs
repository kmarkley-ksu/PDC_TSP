#region Using directives

using System.Diagnostics;
using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using SkmDataStructures2;

#endregion

namespace GraphTester
{
    partial class Form1 : Form
    {
        // create a Graph object
        private Graph<string> SoCalMap = new Graph<string>();

        // create a Hashtable for the shortest distance and paths
        private Hashtable dist = new Hashtable();
        private Hashtable route = new Hashtable();

        const string GRAPH_FILE_NAME = "data.txt";		// the filename that contains the graph data


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadGraphData();		// load the graph data from the file.

//            Graph<string> web = new Graph<string>();
//            web.AddNode("Privacy.htm");
//            web.AddNode("People.aspx");
//            web.AddNode("About.htm");
//            web.AddNode("Index.htm");
//            web.AddNode("Products.aspx");
//            web.AddNode("Contact.aspx");
//
//            web.AddDirectedEdge("People.aspx", "Privacy.htm");  // People -> Privacy
//
//            web.AddDirectedEdge("Privacy.htm", "Index.htm");    // Privacy -> Index
//            web.AddDirectedEdge("Privacy.htm", "About.htm");    // Privacy -> About
//
//            web.AddDirectedEdge("About.htm", "Privacy.htm");    // About -> Privacy
//            web.AddDirectedEdge("About.htm", "People.aspx");    // About -> People
//            web.AddDirectedEdge("About.htm", "Contact.aspx");   // About -> Contact
//
//            web.AddDirectedEdge("Index.htm", "About.htm");      // Index -> About
//            web.AddDirectedEdge("Index.htm", "Contact.aspx");   // Index -> Contacts
//            web.AddDirectedEdge("Index.htm", "Products.aspx");  // Index -> Products
//
//            web.AddDirectedEdge("Products.aspx", "Index.htm");  // Products -> Index
//            web.AddDirectedEdge("Products.aspx", "People.aspx");// Products -> People

        }

        private void ReloadGraphData()
        {
            SoCalMap.Clear();
            dist.Clear();
            route.Clear();

            try
            {
                // populate the graph with the data from the file
                StreamReader sr = File.OpenText(GRAPH_FILE_NAME);

                // iterate through each line
                string line = sr.ReadLine();
                while (line != null)
                {
                    // get the city names and distance					
                    line = Regex.Replace(line, "\"(.*?) (.*?)\"", "$1_$2");

                    string city1 = Regex.Replace(line, "^(.*?) (.*?) (\\d+)$", "$1").Replace('_', ' ');
                    string city2 = Regex.Replace(line, "^(.*?) (.*?) (\\d+)$", "$2").Replace('_', ' ');
                    int distance = Convert.ToInt32(Regex.Replace(line, "^(.*?) (.*?) (\\d+)$", "$3"));

                    // add the nodes to the graph, if needed
                    if (!SoCalMap.Contains(city1))
                        SoCalMap.AddNode(city1);
                    if (!SoCalMap.Contains(city2))
                        SoCalMap.AddNode(city2);
                    SoCalMap.AddUndirectedEdge(city1, city2, distance);

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("There was some unexpected error in reading the file....");
            }


            // reload the combo boxes
            this.startCity.Items.Clear();
            this.endCity.Items.Clear();

            foreach (string cname in SoCalMap)
            {
                startCity.Items.Add(cname);
                endCity.Items.Add(cname);
            }

            if (startCity.Items.Count > 0)
                startCity.SelectedIndex = 0;
            if (endCity.Items.Count > 1)
                endCity.SelectedIndex = 1;
            else if (endCity.Items.Count > 0)
                endCity.SelectedIndex = 0;
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            // Run Notepad, loading the specified file.
            Process.Start("notepad.exe", GRAPH_FILE_NAME);
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            ReloadGraphData();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string start = this.startCity.SelectedItem.ToString();
            string end = this.endCity.SelectedItem.ToString();

            InitDistRouteTables(start);		// initialize the route & distance tables

            NodeList<string> nodes = SoCalMap.Nodes;	// nodes == Q

            /**** START DIJKSTRA ****/
            while (nodes.Count > 0)
            {
                GraphNode<string> u = GetMin(nodes);		// get the minimum node
                nodes.Remove(u);			// remove it from the set Q

                // iterate through all of u's neighbors
                if (u.Neighbors != null)
                    for (int i = 0; i < u.Neighbors.Count; i++)
                        Relax(u.Value, u.Neighbors[i].Value, u.Costs[i]);		// relax each edge
            }	// repeat until Q is empty
            /**** END DIJKSTRA ****/

            // Display results
            string results = "The shortest path from " + start + " to " + end + " is " + dist[end].ToString() + " miles and goes as follows: ";

            Stack traceBackSteps = new Stack();

            string current = end, prev = null;
            do
            {
                prev = current;
                current = (string)route[current];

                string temp = current + " to " + prev + "\r\n";
                traceBackSteps.Push(temp);
            } while (current != start);

            StringBuilder sb = new StringBuilder(30 * traceBackSteps.Count);
            while (traceBackSteps.Count > 0)
                sb.Append((string)traceBackSteps.Pop());

            MessageBox.Show(results + "\r\n\r\n" + sb.ToString());
        }

        /// <summary>
        /// Initializes the distance and route tables used for Dijkstra's Algorithm.
        /// </summary>
        /// <param name="start">The <b>Key</b> to the source Node.</param>
        private void InitDistRouteTables(string start)
        {
            // set the initial distance and route for each city in the graph
            foreach (string cname in SoCalMap)
            {
                dist.Add(cname, Int32.MaxValue);
                route.Add(cname, null);
            }

            // set the initial distance of start to 0
            dist[start] = 0;
        }

        /// <summary>
        /// Relaxes the edge from the Node uCity to vCity.
        /// </summary>
        /// <param name="cost">The distance between uCity and vCity.</param>
        private void Relax(string uCity, string vCity, int cost)
        {
            int distTouCity = (int)dist[uCity];
            int distTovCity = (int)dist[vCity];

            if (distTovCity > distTouCity + cost)
            {
                // update distance and route
                dist[vCity] = distTouCity + cost;
                route[vCity] = uCity;
            }
        }

        /// <summary>
        /// Retrieves the Node from the passed-in NodeList that has the <i>smallest</i> value in the distance table.
        /// </summary>
        /// <remarks>This method of grabbing the smallest Node gives Dijkstra's Algorithm a running time of
        /// O(<i>n</i><sup>2</sup>), where <i>n</i> is the number of nodes in the graph.  A better approach is to
        /// use a <i>priority queue</i> data structure to store the nodes, rather than an array.  Using a priority queue
        /// will improve Dijkstra's running time to O(E lg <i>n</i>), where E is the number of edges.  This approach is
        /// preferred for sparse graphs.  For more information on this, consult the README included in the download.</remarks>
        private GraphNode<string> GetMin(NodeList<string> nodes)
        {
            // find the node in nodes with the smallest distance value
            int minDist = Int32.MaxValue;
            GraphNode<string> minNode = null;
            foreach (GraphNode<string> n in nodes)
            {
                if (((int)dist[n.Value]) <= minDist)
                {
                    minDist = (int)dist[n.Value];
                    minNode = n;
                }
            }

            return minNode;
        }
    }
}