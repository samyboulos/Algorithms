using Algorithms.Models;

namespace Algorithms
{

    public class DeleteNodes: IAlgorithm
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

            var result = RemoveElements(head, 1);
        }

        public ListNode RemoveElements(ListNode head, int val)
        {

            if (head == null)
                return null;

            ListNode dummyHead = new ListNode(0) { next = head };
            ListNode current = dummyHead;

            while (current != null)
            {
                //If we delete the next node then we stay at current node.
                if (current.next != null && current.next.val == val)
                {
                    current.next = current.next.next;
                    if (current == dummyHead)
                    {
                        head = current.next;
                    }
                }
                else
                    current = current.next;
            }

            return head;
        }
    }
}
