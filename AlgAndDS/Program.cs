using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;

int[] values1 = new int[] { 1, 2};

LinkedList.ListNode list = LinkedList.CreateLinkedListFromArray(values1);
LeetcodeTasks.RemoveNthFromEnd(list, 1);

LinkedList.WriteLinkedListToConsole(list);


