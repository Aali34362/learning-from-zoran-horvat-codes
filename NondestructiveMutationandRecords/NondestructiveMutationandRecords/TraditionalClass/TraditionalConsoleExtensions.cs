namespace NondestructiveMutationandRecords.TraditionalClass;

public static class TraditionalConsoleExtensions
{
    public static void TraditionalWriteLines<T>(this TextWriter writer, IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            writer.WriteLine(item);
        }
        Console.WriteLine();
    }

    public static void TraditionalWriteLines<T>(this TextWriter writer, params T[] items) =>
        writer.TraditionalWriteLines((IEnumerable<T>)items);
}
