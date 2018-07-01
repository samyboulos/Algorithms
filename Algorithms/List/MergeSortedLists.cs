using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MergeSortedLists : IAlgorithm
    {
        //This holds pointers to the current node in each of the K lists
        List<ListNode> currents = new List<ListNode>();
        ListNode first = null;
        ListNode tail = null;

        public void Run()
        {
            var l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(5);

            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            var l3 = new ListNode(2);
            l3.next = new ListNode(6);

            ListNode[] input = new ListNode[] { l1, l2, l3 };

            
            var result = MergeKLists(input);

        }


        /// <summary>
        /// Keeps a pointer the current element in each list and loops through them
        /// Finds the minumum value, adds that value to the result 
        /// and advances the pointer that points to it. 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {

            if (lists==null || lists.Length == 0)
            {
                return first;
            }

            foreach (var list in lists)
            {
                if (list != null)
                {
                    currents.Add(list);
                }
            }
            
            while (currents.Any())
            {
                //Find the min current node in all K lists
                int minValue = int.MaxValue;
                int minList = 0;

                for (int x=0; x< currents.Count; x++)
                {
                    if (currents[x].val < minValue)
                    {
                        minValue = currents[x].val;
                        minList = x;
                    }
                }

                var newResult = new ListNode(minValue);

                //Add the value to the tail of the results list
                if (first == null)
                {
                    first = newResult;
                    tail = newResult;
                }
                else
                {
                    tail.next = newResult;
                    tail = newResult;
                }


                //Advance the pointer if it points to a next value or else remove it if it is as the tail
                if (currents[minList].next == null)
                    currents.RemoveAt(minList);
                else
                    currents[minList] = currents[minList].next;

            }

            return first;
        }

        

    }
    



}
