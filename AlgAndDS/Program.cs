using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;

int?[] treeArray = new int?[] { 3, 9, 20, null, null, 15, 7 };
Tree.TreeNode tree = Tree.BuildTree(treeArray);

Tree.WriteTreeToConsole(treeArray);
tree = LeetcodeTasks.InvertTree(tree);
Tree.WriteTreeToConsole(tree);


