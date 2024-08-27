namespace NondestructiveMutationandRecords.UsingInitSetters;

public static class InitSettersConsoleExtensions
{
    public static void InitSettersWriteLines<T>(this TextWriter writer, IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            writer.WriteLine(item);
        }
        Console.WriteLine();
    }

    public static void InitSettersWriteLines<T>(this TextWriter writer, params T[] items) =>
        writer.InitSettersWriteLines((IEnumerable<T>)items);
}
