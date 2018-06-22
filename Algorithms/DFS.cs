using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class DFS : Algorithm
    {

        Stack<Vertex> stack = new Stack<Vertex>();
        List<Vertex> Visited = new List<Vertex>();
        Vertex A = new Vertex('A');
        Vertex B = new Vertex('B');
        Vertex C = new Vertex('C');
        Vertex D = new Vertex('D');
        Vertex E = new Vertex('E');
        Vertex F = new Vertex('F');
        Vertex G = new Vertex('G');
        Vertex H = new Vertex('H');

        private void InitGraph()
        {
            A.Adjacent.Add(B);
            B.Adjacent.Add(A);
            B.Adjacent.Add(C);
            B.Adjacent.Add(H);
            C.Adjacent.Add(B);
            C.Adjacent.Add(D);
            C.Adjacent.Add(E);
            D.Adjacent.Add(C);
            E.Adjacent.Add(C);
            E.Adjacent.Add(F);
            E.Adjacent.Add(G);
            E.Adjacent.Add(H);
            F.Adjacent.Add(E);
            G.Adjacent.Add(E);
            H.Adjacent.Add(B);
            H.Adjacent.Add(E);
        }


        public void Run()
        {
            InitGraph();
            DoDFS();
        }


        private void DoDFS()
        {
            Visited.Add(A);
            Console.WriteLine(A.Name);
            stack.Push(A);

            while (stack.Count > 0)
            {
                var top = stack.Peek();
                var unvisited = top.Adjacent.Where(r => !Visited.Contains(r));
                if (unvisited.Any())
                {
                    var next = unvisited.First();
                    Visited.Add(next);
                    Console.WriteLine(next.Name);
                    stack.Push(next);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

       


    }








   
}
