using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;

int[] values1 = new int[] { 1, 2, 4};
int[] values2 = new int[] { 1, 3, 4};

LinkedList.ListNode list1 = LinkedList.CreateLinkedListFromArray(values1);
LinkedList.ListNode list2 = LinkedList.CreateLinkedListFromArray(values2);

LinkedList.WriteLinkedListToConsole(list1);
LinkedList.WriteLinkedListToConsole(list2);
var list = LeetcodeTasks.MergeTwoLists(list1, list2);
LinkedList.WriteLinkedListToConsole(list);


