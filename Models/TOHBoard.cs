using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    class TOHBoard
    {
        private int n;
        private Stack<int> tower1 = new Stack<int>();
        private Stack<int> tower2 = new Stack<int>();
        private Stack<int> tower3 = new Stack<int>();
        public Tuple<int, int, int> Move;
        public TOHBoard Parent = null;

        public TOHBoard(int n)
        {
            this.n = n;
        }

        public void Init()
        {
            for (int x = n; x >= 1; x--)
            {
                tower1.Push(x);
            }
        }



        public bool IsGoal()
        {
            return tower3.Count == n;
        }

        public string Value
        {
            get
            {
                string tower1Value = "Tower1:";
                string tower2Value = "Tower2:";
                string tower3Value = "Tower3:";

                foreach (int i in tower1)
                {
                    tower1Value += i + ",";
                }
                foreach (int i in tower2)
                {
                    tower2Value += i + ",";
                }
                foreach (int i in tower3)
                {
                    tower3Value += i + ",";
                }

                return tower1Value.TrimEnd(',') + " " + tower2Value.TrimEnd(',') + " " + tower3Value.TrimEnd(',');
            }
        }

        public TOHBoard Copy()
        {
            TOHBoard copy = new TOHBoard(n);
            copy.tower1 = new Stack<int>(this.tower1.ToArray().Reverse());
            copy.tower2 = new Stack<int>(this.tower2.ToArray().Reverse());
            copy.tower3 = new Stack<int>(this.tower3.ToArray().Reverse());
            return copy;
        }

        public TOHBoard [] Children
        {
            get
            {
                if (IsGoal())
                {
                    return new TOHBoard[0];
                }

                List<TOHBoard> children = new List<TOHBoard>();

                TOHBoard child13 = Copy();
                child13.Parent = this;
                if (child13.IsValidMove(1,3))
                {
                    children.Add(child13);
                }

                TOHBoard child12 = Copy();
                child12.Parent = this;
                if (child12.IsValidMove(1, 2))
                {
                    children.Add(child12);
                }

                TOHBoard child23 = Copy();
                child23.Parent = this;
                if (child23.IsValidMove(2,3))
                {
                    children.Add(child23);
                }                

                TOHBoard child32 = Copy();
                child32.Parent = this;
                if (child32.IsValidMove(3, 2))
                {
                    children.Add(child32);
                }

                TOHBoard child21 = Copy();
                child21.Parent = this;
                if (child21.IsValidMove(2, 1))
                {
                    children.Add(child21);
                }

                TOHBoard child31 = Copy();
                child31.Parent = this;
                if (child31.IsValidMove(3, 1))
                {
                    children.Add(child31);
                }

                //Heuristic: 
                //First move for even number board to tower2
                if (Parent == null && n % 2 == 0)
                {
                    return new TOHBoard[] { children[1] };
                }
                //First move for odd number board to tower 3
                else if (Parent == null && n % 2 == 0)
                {
                    return new TOHBoard[] { children[0] };
                }

                return children.ToArray();
            }
        }

        private Stack<int> GetTower(int i)
        {
            switch (i)
            {
                case 1:
                    return tower1;
                case 2:
                    return tower2;
                case 3:
                    return tower3;

                default:
                    throw new Exception("no tower");

            }

        }

        private bool IsValidMove(int towerFromNum, int towerToNum)
        {
            bool valid = false;

            Stack<int> towerFrom = GetTower(towerFromNum);
            Stack<int> towerTo = GetTower(towerToNum);

            if (towerFrom.Count == 0)
            {
                return false;
            }

            int topFrom = int.MaxValue;
            int topTo = int.MaxValue;
            if (towerFrom.Count > 0)
            {
                topFrom = towerFrom.Peek();
            }
            if (towerTo.Count > 0)
            {
                topTo = towerTo.Peek();
            }

            //Rule of the game specifies we cannot move a bigger stone on top of a smaller one.
            bool movingOnBigger = topFrom < topTo; 
            
            //We use a hueristic to find the shortest path.
            //Move even numbered stone on top of odd numbered or vice versa
            bool movingToOppositeParity = (topTo == int.MaxValue) || (topFrom % 2 != topTo % 2);
            //Do not move the same stone twice in a row
            bool moveSameStone = topFrom == Parent.Move?.Item1; 
            bool heuristic = (movingToOppositeParity) &&  !moveSameStone;

            if (movingOnBigger && heuristic) 
            {
                Move = new Tuple<int, int, int>(topFrom,towerFromNum,towerToNum);
                valid = true;
            }
           
            var moved = towerFrom.Pop();
            towerTo.Push(moved);


            return valid;
        }

    }
}
