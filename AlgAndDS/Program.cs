using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;
using AlgAndDS.DataStructuresRealisations;

public class Program
{
    public static void Main()
    {
        TestDoublyList();
    }

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
}
