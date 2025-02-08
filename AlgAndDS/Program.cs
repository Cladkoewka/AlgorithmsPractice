using AlgAndDS.AlgorithmTasks;

int?[] treeArray = new int?[] { 3, 9, 20, null, null, 15, 7 };
LeetcodeTasks.TreeNode tree = LeetcodeTasks.TreeBuilder.BuildTree(treeArray);

Console.WriteLine(LeetcodeTasks.MaxDepth(tree));

