namespace AlgAndDS.DataStructuresRealisations;

public class Stack<T>
{
    private Node<T>? top;
    private int count;

    public int Count => count;
    public bool IsEmpty => count == 0;

    public void Push(T item)
    {
        var newNode = new Node<T>(item);
        newNode.Next = top;
        top = newNode;
        count++;
    }

    public T Pop()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");

        T data = top!.Value;
        top = top.Next;
        count--;
        return data;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");
        return top!.Value;
    }
}