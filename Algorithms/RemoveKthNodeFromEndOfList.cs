public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int k) 
    {
       
   if (head.next == null)
		return null;

	ListNode dummyHead = new ListNode(0);
	dummyHead.next = head;
    
	//We use the Runner technique where we keep two pointers separated by k nodes.
    ListNode p1= head;
	ListNode p2= dummyHead;
   
	for (int x = 0; x < k; x++)
	{
		p1= p1.next;
	}
    
	while (p1 != null)
	{
		p1= p1.next;
        p2= p2.next;
	}

    
	//Now p2 is pointing to the node before the one that should be deleted
    p2.next = p2.next.next;

	if (p2 == dummyHead)
	{
		head= p2.next;
	}
	
	return head;
            
    }
}
