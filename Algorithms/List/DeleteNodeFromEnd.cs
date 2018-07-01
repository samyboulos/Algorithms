using Algorithms.Models;

namespace Algorithms
{


    public class DeleteNodeFromEnd : IAlgorithm
    {

        public void Run()
        {
            ListNode head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };

            var result = RemoveNthFromEnd(head, 1);
        }

        public ListNode RemoveNthFromEnd(ListNode head, int k)
        {

            if (head.next == null)
                return null;

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;

            //We use the Runner technique where we keep two pointers separated by k nodes.
            ListNode p1 = head;
            ListNode p2 = dummyHead;

            for (int x = 0; x < k; x++)
            {
                p1 = p1.next;
            }

            while (p1 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }


            //Now p2 is pointing to the node before the one that should be deleted
            p2.next = p2.next.next;

            if (p2 == dummyHead)
            {
                head = p2.next;
            }

            return head;

        }
    }


}