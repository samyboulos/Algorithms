using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class TowersOfHanoiWithDFS : Algorithm
    {
        int N = 5;
        HashSet<string> Visited = new HashSet<string>();
        List<TOHBoard> goals = new List<TOHBoard>();
        Stack<TOHBoard> stack = new Stack<TOHBoard>();


        public void Run()
        {
            TOHBoard root = new TOHBoard(N);
            root.Init();
            Visited.Add(root.Value);
            stack.Push(root);

            while (stack.Count > 0)
            {
                var top = stack.Peek();
                var unvisited = top.Children.Where(r => !Visited.Contains(r.Value));
                if (unvisited.Any())
                {
                    var next = unvisited.First();
                    Visited.Add(next.Value);
                    stack.Push(next);
                }
                else
                {
                    var leaf= stack.Pop();
                    if (leaf.IsGoal())
                    {
                        goals.Add(leaf);
                        List<Tuple<int, int, int>> Path = new List<Tuple<int, int, int>>();
                        Path.Add(leaf.Move);
                        TOHBoard parent = leaf.Parent;
                        while (parent != null)
                        {
                            Path.Add(parent.Move);
                            parent = parent.Parent;
                        }
                        Path.Remove(null);
                        int x = 0;
                        foreach (var move in Path.ToArray().Reverse())
                        {
                           PrintMove(move);
                            x++;   
                        }

                        Console.WriteLine("Moves " + x);
                    }
                }
            }
            

        }


        public void PrintMove (Tuple<int,int,int> move)
        {
            if (move == null) return;

            Console.WriteLine("Stone " + move.Item1 + ": " + move.Item2 + " => " + move.Item3);
        }



    }


 
}
