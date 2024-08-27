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
/*
In the code snippet list.ForEach(x => Console.Write($"{x,3}"));, the ,3 inside the string interpolation ${x,3} is a formatting specifier.

Here's what it does:

    ${x,3}: The ,3 specifies the field width for the output.
    Field Width (3): It means that the value of x will be right-aligned in a field that is at least 3 characters wide. If the value of x is less than 3 characters long, it will be padded with spaces on the left to fill the width.

Examples:

    If x = 1, the output will be " 1" (with two leading spaces).
    If x = 12, the output will be " 12" (with one leading space).
    If x = 123, the output will be "123" (no spaces, as the width is exactly 3).
    If x = 1234, the output will be "1234" (no padding, as the width is greater than 3, so it simply outputs the value).

This is useful for aligning numbers or text in a tabular format when printing them out.
 */
Console.WriteLine();

//How Does List REALLY Work in .NET
MyList<int> nlist = new();
foreach (int x in data) nlist.Add(x);
list.ForEach(x => Console.Write($"{x,3}"));
Console.WriteLine();