using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;

int[] values = new int[] { 1, 2, 3, 4, 5};

LinkedList.ListNode list = LinkedList.CreateLinkedListFromArray(values);

LinkedList.WriteLinkedListToConsole(list);
list = LeetcodeTasks.ReverseList(list);
LinkedList.WriteLinkedListToConsole(list);


