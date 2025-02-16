namespace AlgAndDS.DataStructures;

public static class LinkedList
{
    public class ListNode 
    { 
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
            this.val = val;
            this.next = next;
        }
    }
    
    public class Node 
    {
        public int val;
        public Node next;
        public Node random;
    
        public Node(int _val) 
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public static ListNode CreateLinkedListFromArray(int[] values)
    {
        if (values.Length == 0)
            return null;

        ListNode head = null;
        ListNode tail = null;

        foreach (var value in values)
        {
            ListNode node = new ListNode(value);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
        }

        return head;
    }

    public static void WriteLinkedListToConsole(ListNode head)
    {
        Console.Write("[");
        while (head != null)
        {
            Console.Write($"{head.val}, ");
            head = head.next;
        }
        Console.Write("]");
        
        Console.WriteLine();
    }
}