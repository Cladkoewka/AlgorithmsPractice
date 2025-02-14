using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;

int[] values1 = new int[] { 1, 2, 3, 4, 5};

LinkedList.ListNode list = LinkedList.CreateLinkedListFromArray(values1);
LeetcodeTasks.ReorderList(list);

LinkedList.WriteLinkedListToConsole(list);


