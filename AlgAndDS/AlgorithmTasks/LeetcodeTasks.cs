using AlgAndDS.DataStructures;

namespace AlgAndDS.AlgorithmTasks;

public static class LeetcodeTasks
{
    /// <summary>
    /// 121. Best Time to Buy and Sell Stock
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static int MaxProfit(int[] prices) {
        int minPrice = Int32.MaxValue;
        int maxProfit = 0;

        foreach (var currentPrice in prices)
        {
            minPrice = Math.Min(currentPrice, minPrice);
            maxProfit = Math.Max(currentPrice - minPrice, maxProfit);
        }
        
        return maxProfit;

        #region FirstIdea
        /*
        int maxProfit = -1;

        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                int profit = prices[j] - prices[i];
                maxProfit = profit > maxProfit ? profit : maxProfit;
            }
        }

        if (maxProfit == -1)
            return 0;

        return maxProfit;
         */
        #endregion
    }

    /// <summary>
    /// 104. Maximum Depth of Binary Tree
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int MaxDepth(Tree.TreeNode? root)
    {
        if (root == null)
            return 0;

        int leftMaxDepth = MaxDepth(root.Left);
        int rightMaxDepth = MaxDepth(root.Right);

        return Math.Max(leftMaxDepth, rightMaxDepth) + 1;
    }

    /// <summary>
    /// 226. Invert Binary Tree
    /// https://leetcode.com/problems/invert-binary-tree/description/
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static Tree.TreeNode InvertTree(Tree.TreeNode? root)
    {
        if (root == null)
            return null;

        Tree.TreeNode temp = root.Left;
        root.Left = InvertTree(root.Right);
        root.Right = InvertTree(temp);

        return root;
    }

    /// <summary>
    /// 110. Balanced Binary Tree
    /// https://leetcode.com/problems/balanced-binary-tree/description/
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool IsBalanced(Tree.TreeNode root)
    {
        if (root == null)
            return true;
        if (Math.Abs(Height(root.Left) - Height(root.Right)) <= 1)
            return true && IsBalanced(root.Left) && IsBalanced(root.Right);
        else
            return false;
    }

    public static int Height(Tree.TreeNode node)
    {
        if (node == null)
            return 0;
        return 1 + Math.Max(Height(node.Left), Height(node.Right));
    }
    
    /// <summary>
    /// 206. Reverse Linked List
    /// https://leetcode.com/problems/reverse-linked-list/description/
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static LinkedList.ListNode ReverseList(LinkedList.ListNode head)
    {
        LinkedList.ListNode reverse = null;
        while (head != null)
        {
            reverse = new LinkedList.ListNode(head.val, reverse);
            head = head.next;
        }

        return reverse;
    }
    
    /// <summary>
    /// 21. Merge Two Sorted Lists
    /// https://leetcode.com/problems/merge-two-sorted-lists/description/
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    public static LinkedList.ListNode MergeTwoLists(LinkedList.ListNode list1, LinkedList.ListNode list2)
    {
        LinkedList.ListNode dummy = new LinkedList.ListNode();
        LinkedList.ListNode resList = dummy;
        

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                resList.next = list1;
                list1 = list1.next;
            }
            else
            {
                resList.next = list2;
                list2 = list2.next;
            }
            resList = resList.next;
        }
        resList.next = list1 ?? list2;
        return dummy.next;
    }

    /// <summary>
    /// 141. Linked List Cycle
    /// https://leetcode.com/problems/linked-list-cycle/description/
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static bool HasCycle(LinkedList.ListNode head)
    {
        if (head == null)
            return false;

        LinkedList.ListNode ptr1 = head;
        LinkedList.ListNode ptr2 = head;
        while (ptr2 != null && ptr2.next != null)
        {
            ptr1 = ptr1.next;
            ptr2 = ptr2.next.next;
            if (ptr1 == ptr2)
                return true;
        }

        return false;
    }
    
    /// <summary>
    /// 143. Reorder List
    /// https://leetcode.com/problems/reorder-list/description/
    /// </summary>
    /// <param name="head"></param>
    public static void ReorderList(LinkedList.ListNode head)
    {
        if (head == null || head.next == null)
            return;

        LinkedList.ListNode middle = midNode(head);
        LinkedList.ListNode newHead = middle.next;
        middle.next = null;

        newHead = reverseLinkedList(newHead);

        LinkedList.ListNode c1 = head;
        LinkedList.ListNode c2 = newHead;
        LinkedList.ListNode f1 = null;
        LinkedList.ListNode f2 = null;
        
        while (c1 != null && c2 != null)
        {
            f1 = c1.next;
            f2 = c2.next;

            c1.next = c2;
            c2.next = f1;

            c1 = f1;
            c2 = f2;
        }
    }

    private static LinkedList.ListNode midNode(LinkedList.ListNode head)
    {
        LinkedList.ListNode fast = head;
        LinkedList.ListNode slow = head;

        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        return slow;
    }

    public static LinkedList.ListNode reverseLinkedList(LinkedList.ListNode head)
    {
        LinkedList.ListNode prev = null;
        LinkedList.ListNode curr = head;
        LinkedList.ListNode next = null;

        while (curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
    
    /// <summary>
    /// 19. Remove Nth Node From End of List
    /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static LinkedList.ListNode RemoveNthFromEnd(LinkedList.ListNode head, int n)
    {
        LinkedList.ListNode curr = head;
        int N = 0;
        
        while (curr != null)
        {
            N++;
            curr = curr.next;
        }

        int removeIndex = N - n - 1;
        curr = head;

        for (int i = 0; i < removeIndex; i++)
        {
            curr = curr.next;
        }

        if (removeIndex == -1)
            return head.next;
        else
        {
            curr.next = curr.next.next;
            return head;
        }
        
    }
}