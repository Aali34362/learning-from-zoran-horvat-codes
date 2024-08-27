namespace DecomposingComplexLINQEX.Presentation;

public static class ConsoleExtensions
{
    public static void WriteLines(this IEnumerable<string> lines)
    {
        foreach (string line in lines)
            Console.WriteLine(line);
    }
}
