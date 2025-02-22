namespace AlgAndDS.DataStructuresRealisations;

public class FixedStack<T>
{
    private T[] items;
    private int top;
    private int capacity;

    public int Count => top + 1;
    public int Capacity => capacity;
    public bool IsEmpty => top == -1;
    public bool IsFull => Count == Capacity;

    public FixedStack(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер стека должен быть больше нуля.");

        capacity = size;
        items = new T[capacity];
        top = -1;
    }

    public void Push(T item)
    {
        if (IsFull)
            throw new InvalidOperationException("Стек полон.");

        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст.");
        return items[top--];
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст.");
        return items[top];
    }
}