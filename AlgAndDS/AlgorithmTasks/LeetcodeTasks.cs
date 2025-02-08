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
    /// DataStructure for tasks with trees
    /// </summary>
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    
    /// <summary>
    /// Class helper with method to build tree from string
    /// </summary>
    public static class TreeBuilder
    {
        /// <summary>
        /// Create tree from string
        /// </summary>
        /// <param name="values">values = [5, null, 3]</param>
        /// <returns></returns>
        public static TreeNode BuildTree(int?[] values)
        {
            if (values.Length == 0 || values[0] == null) return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                if (i < values.Length && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < values.Length && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }
    }

    /// <summary>
    /// 104. Maximum Depth of Binary Tree
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int MaxDepth(TreeNode? root)
    {
        if (root == null)
            return 0;

        int leftMaxDepth = MaxDepth(root.left);
        int rightMaxDepth = MaxDepth(root.right);

        return Math.Max(leftMaxDepth, rightMaxDepth) + 1;
    }
}