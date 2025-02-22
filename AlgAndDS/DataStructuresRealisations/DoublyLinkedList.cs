using System.Collections;

namespace AlgAndDS.DataStructuresRealisations;

public class DoublyNode<T>
{
    public T Value { get; set; }
    public DoublyNode<T> Next { get; set; }
    public DoublyNode<T> Prev { get; set; }
    
    public DoublyNode(T value, DoublyNode<T> next = null, DoublyNode<T> prev = null)
    {
        Value = value;
        Next = next;
        Prev = prev;
    }
}

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private DoublyNode<T>? head;
    private DoublyNode<T>? tail;

    public void AddFirst(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
    }

    public void AddLast(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);

        if (tail == null)
        {
            tail = newNode;
            head = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public bool Remove(T data)
    {
        if (head == null)
            return false;

        DoublyNode<T> current = head;
        while (current != null && !current.Value!.Equals(data))
        {
            current = current.Next;
        }

        if (current == null)
            return false;

        if (current == head)
            head = head.Next;

        if (current == tail)
            tail = tail.Prev;

        if (current.Prev != null) 
            current.Prev.Next = current.Next;

        if (current.Next != null)
            current.Next.Prev = current.Prev;
        
        return true;
    }

    public DoublyNode<T> Find(T value)
    {
        DoublyNode<T> current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return current;
            current = current.Next;
        }

        return null;
    }

    public DoublyNode<T>? GetAtIndex(int index)
    {
        if (index < 0) throw new IndexOutOfRangeException("Индекс не может быть меньше нуля");

        DoublyNode<T> current = head;
        int counter = 0;

        while (current != null)
        {
            if (counter == index)
                return current;
            current = current.Next;
            counter++;
        }
        
        throw new IndexOutOfRangeException("Индекс за пределами списка.");
    }
    
    

    public void PrintForward()
    {
        DoublyNode<T> current = head;
        while (current != null)
        {
            Console.Write(current.Value + " <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public void PrintBackward()
    {
        DoublyNode<T> current = tail;
        while (current != null)
        {
            Console.Write(current.Value + " <-> ");
            current = current.Prev;
        }
        Console.WriteLine("null");
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}