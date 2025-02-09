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
}