using AlgAndDS.Algorithms;
using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;
using AlgAndDS.DataStructuresRealisations;

public class Program
{
    public static void Main()
    {
        int[] arr = { 5, 3, 8, 4, 2 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", arr));

        SortingAlgorithms.SelectionSort(arr);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
    }

#region Data Structures Tests

    public static void TestLinkedList()
    {
        var list = new AlgAndDS.DataStructuresRealisations.LinkedList<int>();

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.Print();

        list.AddFirst(0);
        list.Print();

        list.Remove(2);
        list.Print();

        var node = list.Find(3);
        Console.WriteLine(node != null ? $"Найден узел: {node.Value}" : "Элемент не найден");
    }
    
    static void TestDoublyList()
    {
        var list = new DoublyLinkedList<int>();

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.PrintForward();  
        list.PrintBackward(); 

        list.AddFirst(0);
        list.PrintForward(); 

        list.Remove(2);
        list.PrintForward();  

        var node = list.Find(3);
        Console.WriteLine(node != null ? $"Найден узел: {node.Value}" : "Элемент не найден");
        
        var nodeAtIndex = list.GetAtIndex(2);
        Console.WriteLine(nodeAtIndex != null ? $"Элемент на индексе 2: {nodeAtIndex.Value}" : "Элемент не найден");
    }
    
    static void TestStack()
    {
        var stack = new AlgAndDS.DataStructuresRealisations.Stack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine($"Peek: {stack.Peek()}");

        while (!stack.IsEmpty)
        {
            Console.WriteLine($"Pop: {stack.Pop()}");
        }
    }
    
    static void TestFixedStack()
    {
        var stack = new FixedStack<int>(3);
        
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        
        // stack.Push(40); // Ошибка: стек заполнен

        Console.WriteLine($"Peek: {stack.Peek()}"); 

        while (!stack.IsEmpty)
        {
            Console.WriteLine($"Pop: {stack.Pop()}");
        }

    }
    
    static void TestQueue()
    {
        var queue = new AlgAndDS.DataStructuresRealisations.Queue<int>();
        
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine($"Peek: {queue.Peek()}"); // 10

        while (!queue.IsEmpty)
        {
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
        }

        // queue.Dequeue(); // Ошибка: очередь пуста
    }
    
    static void TestHashTable()
    {
        var hashTable = new HashTable<string, int>();

        hashTable.Insert("Alice", 25);
        hashTable.Insert("Bob", 30);
        hashTable.Insert("Charlie", 35);

        Console.WriteLine($"Alice: {hashTable.Get("Alice")}");
        Console.WriteLine($"Contains 'Bob': {hashTable.Contains("Bob")}");

        hashTable.Remove("Alice");
        Console.WriteLine($"Contains 'Alice' after removal: {hashTable.Contains("Alice")}");
    }

#endregion
    
}
