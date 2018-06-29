public class DeleteNodesFromList {
    public ListNode RemoveElements(ListNode head, int val) 
    {
        
        if (head == null)
		return null;

	    ListNode dummyHead = new ListNode(0) { next = head };
	    ListNode current = dummyHead;

	    while (current != null)
	    {
		    //If we delete the next node then we stay at current node.
            if (current.next != null  && current.next.val == val)
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
