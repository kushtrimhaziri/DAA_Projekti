using System;
using System.Collections.Generic;
using System.Linq;

namespace DAA_Projekti
{
    class Program 
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Grafi 1 ");
            Graph g1 = new Graph(6);
            g1.AddEdge(0, 1);
            g1.AddEdge(0, 2);
            g1.AddEdge(0, 3);
            g1.AddEdge(0, 4);
            g1.AddEdge(0, 5);
            g1.AddEdge(1, 2);
            g1.AddEdge(1, 3);
            g1.AddEdge(1, 4);
            g1.AddEdge(1, 5);
            g1.AddEdge(2, 3);
            g1.AddEdge(2, 4);
            g1.AddEdge(2, 5);
            g1.AddEdge(3, 4);
            g1.AddEdge(3, 5);
            g1.AddEdge(4, 5);

            g1.DFS(3);
            g1.BFS(3);
            g1.ConvertToMatrice();
            Console.WriteLine();
            Console.WriteLine(g1.GraphIsEulerian());
            Console.WriteLine(g1.isHamiltonian());
            Console.WriteLine();
            HamiltonianCycle hamiltonian1 = new HamiltonianCycle(6);
            hamiltonian1.hamCycle(g1.ConvertToMatrice());
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("Grafi 2");

            Graph g2 = new Graph(7);
            g2.AddEdge(0, 1);
            g2.AddEdge(0, 2);
            g2.AddEdge(0, 4);
            g2.AddEdge(0, 4);
            g2.AddEdge(1, 5);
            g2.AddEdge(1, 6);
            g2.AddEdge(2, 3);
            g2.AddEdge(4, 5);

            g2.DFS(3);
            g2.BFS(3);
            g2.ConvertToMatrice();
            Console.WriteLine();
            Console.WriteLine(g2.GraphIsEulerian());
            Console.WriteLine(g2.isHamiltonian());
            Console.WriteLine();
            HamiltonianCycle hamiltonian2 = new HamiltonianCycle(7);
            hamiltonian2.hamCycle(g2.ConvertToMatrice());
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("Grafi 3 ");

            Graph g3 = new Graph(7);

            g3.AddEdge(0, 1);
            g3.AddEdge(0, 4);
            g3.AddEdge(0, 5);
            g3.AddEdge(0, 6);
            g3.AddEdge(1, 2);
            g3.AddEdge(1, 3);
            g3.AddEdge(1, 6);
            g3.AddEdge(2, 3);
            g3.AddEdge(3, 4);
            g3.AddEdge(3, 6);
            g3.AddEdge(4, 5);
            g3.AddEdge(4, 6);

            g3.DFS(3);
            g3.BFS(3);
            g3.ConvertToMatrice();
            Console.WriteLine();
            Console.WriteLine(g3.GraphIsEulerian());
            Console.WriteLine(g3.isHamiltonian());
            Console.WriteLine();
            HamiltonianCycle hamiltonian3 =  new HamiltonianCycle(7);
            hamiltonian3.hamCycle(g3.ConvertToMatrice());





            Console.ReadKey();
        }
    }



   

}
