namespace AlgAndDS.DataStructures;

public static class Tree
{
    public class TreeNode
    {
        public int? Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    public static TreeNode BuildTree(int?[] values)
    {
        if (values.Length == 0 || values[0] == null)
            return null;

        TreeNode rootNode = new TreeNode(values[0].Value);
        
        Queue<TreeNode> treeNodes = new Queue<TreeNode>();
        treeNodes.Enqueue(rootNode);

        int i = 1;
        while (i < values.Length)
        {
            TreeNode currentNode = treeNodes.Dequeue();

            if (i < values.Length && values[i] != null)
            {
                currentNode.Left = new TreeNode(values[i].Value);
                treeNodes.Enqueue(currentNode.Left);
            }
            i++;
            
            if (i < values.Length && values[i] != null)
            {
                currentNode.Right = new TreeNode(values[i].Value);
                treeNodes.Enqueue(currentNode.Right);
            }
            i++;
        }

        return rootNode;
    }
    
    public static int?[] RebuildTree(TreeNode rootNode)
    {
        if (rootNode.Value == 0)
            return new int?[] {};

        List<int?> result = new List<int?>();
        
        Queue<TreeNode> nodesQueue = new Queue<TreeNode>();
        nodesQueue.Enqueue(rootNode);

        while (nodesQueue.Count > 0)
        {
            TreeNode currentNode = nodesQueue.Dequeue();
            result.Add(currentNode.Value);

            if (currentNode.Left != null)
            {
                nodesQueue.Enqueue(currentNode.Left);
            }
            else
            {
                result.Add(null);
            }
            
            if (currentNode.Right != null)
            {
                nodesQueue.Enqueue(currentNode.Right);
            }
            else
            {
                result.Add(null);
            }
        }
        
        while (result.Count > 0 && result[^1] == null)
        {
            result.RemoveAt(result.Count - 1);
        }

        return result.ToArray();
    }

    public static void WriteTreeToConsole(TreeNode tree)
    {
        var values = RebuildTree(tree);

        Console.Write("[");
        foreach (var value in values)
        {
            Console.Write($"{(value != null ? value : "null")}, ");
        }
        Console.Write("]");
        
        Console.WriteLine();
    }
    
    public static void WriteTreeToConsole(int?[] values)
    {
        Console.Write("[");
        foreach (var value in values)
        {
            Console.Write($"{value}, ");
        }
        Console.Write("]");
        
        Console.WriteLine();
    }
    
}