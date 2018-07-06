using Algorithms.Models;

namespace Algorithms
{
    public class PartitionList: IAlgorithm
    {

        public void Run()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(4);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(2);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(2);

            Run(head, 3);
        }

        public ListNode Run(ListNode head, int x)
        {
            if (head == null)
                return null;

            ListNode head2 = null;
            ListNode tail2 = null;
            ListNode dummyHead = new ListNode(0) { next = head };
            ListNode current = dummyHead;

            while (current.next != null)
            {
                if (current.next.val >= x)
                {
                    #region Add copy of the node to the second partition
                    ListNode node = new ListNode(current.next.val);
                    if (head2 == null)
                    {
                        head2 = node;
                    }
                    else
                    {
                        tail2.next = node;
                    }

                    //Either way
                    tail2 = node;
                    #endregion

                    if (current == dummyHead)
                    {
                        head = dummyHead.next.next; //Advance head
                    }

                    //Discard next node
                    current.next = current.next.next;
                    //Do not advace current in this case as we need to look at the new next node
                }
                else
                {
                    current = current.next;
                }
            }

            //if all nodes have been moved to other partition then all we have is other partition
            if (current == dummyHead)
                head = head2;
            else
                current.next = head2; //concat two partions


            return head;
        }
    }
}
