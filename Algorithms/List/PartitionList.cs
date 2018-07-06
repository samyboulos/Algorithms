void Main()
{
	ListNode head= new ListNode(1);
	head.next= new ListNode(4);
	head.next.next= new ListNode(3);
	head.next.next.next= new ListNode(2);
	head.next.next.next.next= new ListNode(5);
	head.next.next.next.next.next= new ListNode(2);
	
	new Solution().Partition(head, 3);
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode Partition(ListNode head, int x) 
    {
        if (head == null)
			return null;

		ListNode head2 = null;
		ListNode tail2 = null;
		ListNode dummyHead = new ListNode(0) {next= head} ;
		ListNode current = dummyHead;
        
		while (current.next != null)
		{
			if (current.next.val >= x)
			{
				//Add copy of the node to the second partition
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

				if (current == dummyHead)
				{
					head = dummyHead.next.next; //Advance head
				}

                current.next = current.next.next;
			}
			else
			{
				current = current.next;
			}
		}

       if(current==dummyHead)
			head = head2;
		else
        	current.next= head2;


		return head;    
    }
}
