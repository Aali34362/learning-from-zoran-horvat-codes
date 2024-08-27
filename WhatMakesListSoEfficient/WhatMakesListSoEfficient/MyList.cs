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
/*
The code snippet you provided defines an indexer in a class. 
This indexer allows instances of the class to be accessed using array-like syntax, where T is the type of elements being stored.

Components:
public T this[int index]:
This defines an indexer for the class. 
It allows instances of the class to be accessed like an array using an index ([]).
The type T represents the type of the items that the indexer returns or sets. 
It is likely a generic class or a specific type that the class is handling.

    get => this.Content[this.ValidIndex(index)];:
        The get accessor allows you to retrieve the value at a specific index.
        this.ValidIndex(index) is likely a method in the class that validates the index to ensure it's within a valid range.
        this.Content is assumed to be an internal data structure (like an array, list, or another collection) that stores the elements. 
        The ValidIndex method is used to check the index before accessing the Content.
    set => this.Content[this.ValidIndex(index)] = value;:
        The set accessor allows you to assign a value to the specified index.
        value is a keyword that represents the value being assigned in the set accessor.
        The same ValidIndex(index) method is called to validate the index before setting the value in Content.

Example Usage:

Assume you have a class MyCollection with this indexer:

MyCollection<int> myCollection = new MyCollection<int>();
myCollection[0] = 10; // Uses the 'set' accessor to assign the value 10 at index 0.
int value = myCollection[0]; // Uses the 'get' accessor to retrieve the value at index 0.

What Happens Internally:

    Retrieving a Value:
        When int value = myCollection[0]; is called, the get accessor is invoked.
        ValidIndex(0) checks if the index 0 is valid.
        If valid, Content[0] is returned.

    Setting a Value:
        When myCollection[0] = 10; is called, the set accessor is invoked.
        ValidIndex(0) checks if the index 0 is valid.
        If valid, Content[0] = 10 sets the value at index 0.

Benefits of This Pattern:

    Validation: The ValidIndex(index) method ensures that any access to the underlying data structure is safe and within bounds.
    Encapsulation: This approach encapsulates the internal data structure (Content) and provides a controlled way to access and modify it.
    Array-Like Syntax: The indexer allows the class to be used with intuitive array-like syntax, improving readability and ease of use.
*/

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