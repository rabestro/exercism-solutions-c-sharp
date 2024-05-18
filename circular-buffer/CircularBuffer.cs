using System;
using System.Collections.Generic;

public class CircularBuffer<T> : Queue<T>
{
    private readonly int _capacity;

    public CircularBuffer(int capacity) => _capacity = capacity;

    public T Read() => Dequeue();

    public void Write(T value)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Cannot write to a full buffer.");
        }

        Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (IsFull())
        {
            Dequeue();
        }

        Enqueue(value);
    }

    private bool IsFull() => Count == _capacity;
}