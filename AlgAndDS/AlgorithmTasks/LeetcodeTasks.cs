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
    
    /// <summary>
    /// 138. Copy List with Random Pointer
    /// https://leetcode.com/problems/copy-list-with-random-pointer/description/
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static LinkedList.Node CopyRandomList(LinkedList.Node head)
    {
        if (head == null)
            return null;

        Dictionary<LinkedList.Node, LinkedList.Node> oldToNew = new Dictionary<LinkedList.Node, LinkedList.Node>();

        LinkedList.Node curr = head;
        while (curr != null)
        {
            oldToNew[curr] = new LinkedList.Node(curr.val);
            curr = curr.next;
        }

        curr = head;
        while (curr != null)
        {
            oldToNew[curr].next = curr.next != null ? oldToNew[curr.next] : null;
            oldToNew[curr].random = curr.random != null ? oldToNew[curr.random] : null;
            curr = curr.next;
        }

        return oldToNew[head];
    }
    
    /// <summary>
    /// 66. Plus One
    /// https://leetcode.com/problems/plus-one/description/?envType=problem-list-v2&envId=array
    /// </summary>
    /// <param name="digits"></param>
    /// <returns></returns>
    public static int[] PlusOne(int[] digits)
    {
        int n = digits.Length;

        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }
            else
            {
                digits[i] = 0;
            }
        }

        int[] newDigits = new int[n + 1];
        newDigits[0] = 1;

        return newDigits;
    }
    
    /// <summary>
    /// 36. Valid Sudoku
    /// https://leetcode.com/problems/valid-sudoku/description/
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public static bool IsValidSudoku(char[][] board)
    {
        HashSet<char>[] row = new HashSet<char>[9];
        HashSet<char>[] col = new HashSet<char>[9];
        HashSet<char>[] box = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            row[i] = new HashSet<char>();
            col[i] = new HashSet<char>();
            box[i] = new HashSet<char>();
        }

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                char elem = board[r][c];
                if (elem == '.')
                {
                    continue;
                }

                if (!row[r].Add(elem))
                    return false;

                if (!col[c].Add(elem))
                    return false;

                int b = (3 * (r / 3)) + (c / 3);
                if (!box[b].Add(elem))
                    return false;
            }
        }

        return true;
    }
    
    /// <summary>
    /// 128. Longest Consecutive Sequence
    /// https://leetcode.com/problems/longest-consecutive-sequence/description/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        HashSet<int> hashSet = new HashSet<int>(nums);
        int maxLength = 1;
        foreach (int number in hashSet)
        {
            if (hashSet.Contains(number - 1))
                continue;

            int counter = 1;
            while (hashSet.Contains(number + counter))
            {
                counter++;
            }

            maxLength = Math.Max(counter, maxLength);
        }

        return maxLength;
    }
    
    /// <summary>
    /// 20. Valid Parentheses
    /// https://leetcode.com/problems/valid-parentheses/description/
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        foreach(var c in s)
        {
            if(c == '(' || c == '{' || c == '[')
                stack.Push(c);
            else
            {
                if (stack.Count == 0)
                    return false;
                
                char lastElem = stack.Pop();
                
                if (c == ')' && lastElem != '(')
                    return false;
                if (c == ']' && lastElem != '[')
                    return false;
                if (c == '}' && lastElem != '{')
                    return false;
            }
        }

        return (stack.Count == 0);
    }
    
    /// <summary>
    /// 739. Daily Temperatures
    /// https://leetcode.com/problems/daily-temperatures/description/
    /// </summary>
    /// <param name="temperatures"></param>
    /// <returns></returns>
    public static int[] DailyTemperatures(int[] temperatures)
    {
        Stack<int> stack = new Stack<int>();
        int[] answer = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                int index = stack.Pop();
                answer[index] = i - index;
            }
            stack.Push(i);
        }

        return answer;
    }
    
    /// <summary>
    /// 1980. Find Unique Binary String
    /// https://leetcode.com/problems/find-unique-binary-string/description
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static string FindDifferentBinaryString(string[] nums) {
        char[] res = new char[nums.Length];

        for(int i = 0; i < nums.Length; i++)
        {
            res[i] = nums[i][i] == '0' ? '1' : '0';
        }

        return new string(res);
    }

    /// <summary>
    /// 1261. Find Elements in a Contaminated Binary Tree
    /// https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/description/
    /// </summary>
    public class FindElementsInContaminatedTree
    {
        private HashSet<int> set;

        public FindElementsInContaminatedTree(Tree.TreeNode node)
        {
            set = new HashSet<int>();
            RecoverTree(node, 0);
        }

        public void RecoverTree(Tree.TreeNode root, int value)
        {
            if (root == null) return;
            set.Add(value);
            root.Value = value;
            RecoverTree(root.Left, 2 * value + 1);
            RecoverTree(root.Right, 2 * value + 2);
            
        }
    }
}