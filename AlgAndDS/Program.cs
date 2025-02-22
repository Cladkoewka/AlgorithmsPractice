using AlgAndDS.AlgorithmTasks;
using AlgAndDS.DataStructures;
using AlgAndDS.DataStructuresRealisations;

public class Program
{
    public static void Main()
    {
        TestLinkedList();
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
}
