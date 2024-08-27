using WhatMakesListSoEfficient;

IEnumerable<int> data = Enumerable.Range(0, 20);

List<int> list = new();
foreach (int x in data) list.Add(x);
Console.WriteLine("Using generic list:");
list.ForEach(x => Console.Write($"{x,3}"));
Console.WriteLine();

int[] array = new int[16];
int count = 0;
foreach (int x in data)
{
    if (count == array.Length)
    {
        int[] newArray = new int[array.Length * 2];
        Array.Copy(array, newArray, array.Length);
        array = newArray;
    }
    array[count++] = x;
}

Console.WriteLine();
Console.WriteLine(new string('-', 80));
Console.WriteLine();
Console.WriteLine("Using resizable array:");
for (int i = 0; i < count; i++) Console.Write($"{array[i],3}");
Console.WriteLine();

MyList<int> myList = new();
foreach (int x in data) myList.Add(x);

Console.WriteLine();
Console.WriteLine(new string('-', 80));
Console.WriteLine();
Console.WriteLine("Using custom list:");
myList.ForEach(x => Console.Write($"{x,3}"));
Console.WriteLine();
