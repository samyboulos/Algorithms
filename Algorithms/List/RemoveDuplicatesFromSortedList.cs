using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RemoveDuplicatesFromSortedList : IAlgorithm
    {
        public void Run()
        {
            ListNode head = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(3)
                        }
                    }
                }
            };


        }

        private ListNode Do(ListNode head)
        {
            if (head == null)
                return null;

            ListNode slow = head;
            ListNode fast = head;
            while (fast != null)
            {
                if (slow.val != fast.val)
                {
                    slow.next = fast;
                    slow = fast;
                }

                fast = fast.next;
            }

            slow.next = null;
            return head;
        }
    }
}
