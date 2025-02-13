using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;

int[] values1 = new int[] { 1, 2, 4};
int[] values2 = new int[] { 1, 3, 4};

LinkedList.ListNode list1 = LinkedList.CreateLinkedListFromArray(values1);
list1.next.next.next = list1;

Console.WriteLine(LeetcodeTasks.HasCycle(list1));


