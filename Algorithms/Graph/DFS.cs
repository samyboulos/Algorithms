using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class DFS : IAlgorithm
    {

        Stack<Vertex> stack = new Stack<Vertex>();

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
            Console.WriteLine("Iterative");
            DoDFS();

            //DoDFSRecursive(A);
        }


        private void DoDFS()
        {
            A.Visited = true;
            Console.WriteLine(A.Name);
            stack.Push(A);

            while (stack.Count > 0)
            {
                var top = stack.Peek();
                var unvisited = top.Adjacent.Where(r => r.Visited==false);
                if (unvisited.Any())
                {
                    var next = unvisited.First();
                    next.Visited = true;
                    Console.WriteLine(next.Name);
                    stack.Push(next);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        private void DoDFSRecursive(Vertex v)
        {
            if (v.Visited)
                return;

            v.Visited = true;
            Console.WriteLine(v.Name);

            foreach (var child in v.Adjacent)
            {
                DoDFSRecursive(child);
            }
        }


    }








   
}
