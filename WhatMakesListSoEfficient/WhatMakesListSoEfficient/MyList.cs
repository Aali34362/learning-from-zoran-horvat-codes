using System.Collections;

namespace WhatMakesListSoEfficient;

public class MyList<T> : IEnumerable<T>
{
    public MyList() : this(16) { }
    public MyList(int capacity)
    {
        this.Content = new T[capacity];
        this.Count = 0;
    }

    public int Capacity => this.Content.Length;
    public int Count { get; private set; }
    private T[] Content { get; set; }

    public T this[int index]
    {
        get => this.Content[this.ValidIndex(index)];
        set => this.Content[this.ValidIndex(index)] = value;
    }

    private int ValidIndex(int index) =>
        index < this.Count ? index : throw new IndexOutOfRangeException();

    public void Add(T item)
    {
        this.EnsureCapacity(this.Count + 1);
        this.Content[this.Count++] = item;
    }

    public void RemoveAt(int index)
    {
        Array.Copy(Content, ValidIndex(index) + 1, Content, index, Count - index - 1);
        this.Count--;
    }

    public void EnsureCapacity(int capacity)
    {
        if (this.Capacity >= capacity) return;
        int newCapacity = this.Capacity > 0 ? this.Capacity * 2 : 1;
        while (newCapacity < capacity) newCapacity *= 2;
        T[] newContent = new T[newCapacity];
        Array.Copy(this.Content, newContent, this.Count);
        this.Content = newContent;
    }

    public void Clear() => this.Count = 0;

    public void Sort() =>
        Array.Sort(this.Content, 0, this.Count);

    public void Sort(IComparer<T> comparer) =>
        Array.Sort(this.Content, 0, this.Count, comparer);

    public void ForEach(Action<T> action)
    {
        foreach (T item in this) action(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++) yield return this.Content[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}