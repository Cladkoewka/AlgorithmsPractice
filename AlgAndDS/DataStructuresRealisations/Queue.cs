namespace AlgAndDS.DataStructuresRealisations;

public class Queue<T>
{
    private Node<T>? head;
    private Node<T>? tail;
    private int count;

    public int Count => count;
    public bool IsEmpty => count == 0;

    public void Enqueue(T item)
    {
        var newNode = new Node<T>(item);
        if (tail != null)
            tail.Next = newNode;
        
        tail = newNode;

        if (head == null)
            head = tail;

        count++;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Очередь пуста");

        T data = head!.Value;
        head = head.Next;
        if (head == null)
            tail = null;
        
        count--;
        return data;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Очередь пуста");

        return head!.Value;
    }
}