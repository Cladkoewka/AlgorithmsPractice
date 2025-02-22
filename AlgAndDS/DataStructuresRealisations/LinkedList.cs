namespace AlgAndDS.DataStructuresRealisations;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value, Node<T> next = null)
    {
        Value = value;
        Next = next;
    }
    
}

public class LinkedList<T>
{
    private Node<T>? head;

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data, head);
        head = newNode;
    }

    public void AddLast(T data)
    {
        var newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            return;
        }
        
        Node<T> current = head;
        while (current.Next != null) 
            current = current.Next;

        current.Next = newNode;
    }

    public bool Remove(T data)
    {
        if (head == null)
            return false;

        Node<T> current = head;
        while (current.Next != null && !current.Next.Value!.Equals(data)) 
            current = current.Next;

        if (current.Next == null)
            return false;

        current.Next = current.Next.Next;
        return true;
    }

    public Node<T>? Find(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Value!.Equals(data))
                return current;
            current = current.Next;
        }
        return null;
    }

    public void Print()
    {
        var current = head;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}