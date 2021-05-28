using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAA_Projekti
{
    public class Graph
    {
        private int Vertex;

        private List<int>[] connectionsOfVertexes;

        public Graph(int vertex)
        {
            Vertex = vertex;
            connectionsOfVertexes = new List<int>[vertex];
            for (int i = 0; i < vertex; ++i)
                connectionsOfVertexes[i] = new List<int>();
        }
        public void AddEdge(int vertex, int w)
        {
            // Graf jo i direktuar
            connectionsOfVertexes[vertex].Add(w);
            connectionsOfVertexes[w].Add(vertex);
        }
        public string isHamiltonian()
        {
            
            if (!isConnected())
            {
                return "\nGrafi nuk eshte Hamiltonian, sepse nuk eshte i lidhur";
            }
            else if (Vertex < 3)
            {
                return "\nGrafi nuk eshte Hamiltonian, sepse ka numer te nyjeve me te vogel se 3";
            }
            else if (DiracTheorem() && OresTheorem())
            {
                return "\nGrafi eshte Hamiltonian nga teorema e Dirakut dhe Oresit";
            }
            else if (DiracTheorem() && !OresTheorem())
            {
                return "\nGrafi eshte Hamiltonian nga teorema e Dirakut dhe nuk mund te percaktohet nga teorema e Oresit";
            }
            else if (OresTheorem() && !DiracTheorem())
            {
                return "\nGrafi eshte Hamiltonian nga teorema e Oresit dhe nuk mund te percaktohet nga teorema e Dirakut";
            }
            else
            {
                return "\nGrafi nuk mund te percaktohet nese eshte Hamiltonian per nga teorema e Dirakut apo nga teorema e Oresit ";
            }
        }


        public int[,] ConvertToMatrice()
        {
            int[,] matriceCoverted = new int[Vertex, Vertex];
            for (int j = 0; j < connectionsOfVertexes.Count(); j++)
            {
                for (int i = 0; i < Vertex; i++)
                {

                    if (connectionsOfVertexes[j].Contains(i))
                    {
                        matriceCoverted[j, i] = 1;
                    }

                }
            }

            return matriceCoverted;
        }
        public bool OresTheorem()
        {
            int Count = 0;
            int Count2 = 0;
            var list = new List<KeyValuePair<int, int>>();
            for (int j = 0; j < connectionsOfVertexes.Count(); j++)
            {
                for (int i = 0; i < Vertex; i++)
                {
                    if (true)
                    {
                        if (!connectionsOfVertexes[j].Contains(i))
                        {
                            list.Add(new KeyValuePair<int, int>(j, i));
                            Count++;
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, int> acct in list)
            {
                int a = acct.Key;
                int b = acct.Value;

                int nr1 = connectionsOfVertexes[a].Count();
                int nr2 = connectionsOfVertexes[b].Count();

                if (nr1 + nr2 > Vertex)
                {
                    Count2++;
                }
            }

            if (Count == Count2)
            {
                return true;
            }
            return false;
        }

        public bool DiracTheorem()
        {
            int k = Vertex / 2;
            int counter = 0;
            foreach (var item in connectionsOfVertexes)
            {
                if (item.Count() >= k)
                {
                    counter++;
                }
            }

            if (counter == Vertex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void DFSrec(int vertex, bool[] visited)
        {

            visited[vertex] = true;
            Console.Write(vertex + " ");

            List<int> vertexList = connectionsOfVertexes[vertex];
            foreach (var n in vertexList)
            {
                if (!visited[n])
                    DFSrec(n, visited);
            }
        }
        public void DFSrec1(int vertex, bool[] visited)
        {

            visited[vertex] = true;

            List<int> vertexList = connectionsOfVertexes[vertex];
            foreach (var n in vertexList)
            {
                if (!visited[n])
                    DFSrec1(n, visited);
            }
        }
        public void BFS(int s)
        {
            
            Console.WriteLine("\nGjeresia se pari (BFS):");

            bool[] visited = new bool[Vertex];
            for (int i = 0; i < Vertex; i++)
                visited[i] = false;

            LinkedList<int> queue = new LinkedList<int>();


            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                List<int> list = connectionsOfVertexes[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }

        public void DFS(int vertex)
        {
            Console.WriteLine("\nThellesia se pari (DFS) ");
            bool[] visited = new bool[Vertex];

            DFSrec(vertex, visited);

        }

        public bool isConnected()
        {

            bool[] visited = new bool[Vertex];
            int i;
            for (i = 0; i < Vertex; i++)
                visited[i] = false;


            for (i = 0; i < Vertex; i++)
                if (connectionsOfVertexes[i].Count != 0)
                    break;

            if (i == Vertex)
                return true;

            DFSrec1(i, visited);

            for (i = 0; i < Vertex; i++)
                if (visited[i] == false && connectionsOfVertexes[i].Count > 0)
                    return false;

            return true;
        }
        public String GraphIsEulerian()
        {

            if (isConnected() == false)
                return "\nGrafi nuk eshte Eulerian sepse nuk eshte i lidhur";

            int odd = 0;
            for (int i = 0; i < Vertex; i++)
                if (connectionsOfVertexes[i].Count % 2 != 0)
                    odd++;

            if (odd > 2)
                return "\nGrafi nuk eshte Eulerian, sepse me shume se dy nyje te tij kane shkalle teke";


            return (odd == 2) ? "\nGrafi ka rruge te Eulerit" : "\nGrafi ka qark te Eulerit";
        }

    }
}
