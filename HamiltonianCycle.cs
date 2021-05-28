using System;
using System.Collections.Generic;
using System.Text;

namespace DAA_Projekti
{
    public class HamiltonianCycle
    {
        public int V;
        int[] path;
        public HamiltonianCycle(int v)
        {
            V = v;
        }

        bool isSafe(int v, int[,] graph,
                    int[] path, int pos)
        {

            if (graph[path[pos - 1], v] == 0)
                return false;


            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }


        bool HamiltonCycleRec(int[,] graph, int[] path, int pos)
        {

            if (pos == V)
            {

                if (graph[path[pos - 1], path[0]] == 1)
                    return true;
                else
                    return false;
            }


            for (int v = 1; v < V; v++)
            {

                if (isSafe(v, graph, path, pos))
                {
                    path[pos] = v;

                    if (HamiltonCycleRec(graph, path, pos + 1) == true)
                        return true;

                    path[pos] = -1;
                }
            }

            return false;
        }


        public int hamCycle(int[,] graph)
        {
            path = new int[V];
            for (int i = 0; i < V; i++)
                path[i] = -1;


            path[0] = 0;
            if (HamiltonCycleRec(graph, path, 1) == false)
            {
                Console.WriteLine("\nNuk ekziston ndonje rruge qe krijon qark te Hamiltonit");
                return 0;
            }

            PrintoPathin(path);
            return 1;
        }


        void PrintoPathin(int[] path)
        {
            Console.WriteLine("Rruga e pershkuar me poshte paraqet qark te Hamiltonit");
            for (int i = 0; i < V; i++)
                Console.Write(" " + path[i] + " ");


            Console.WriteLine(" " + path[0] + " ");
        }



    }
}
