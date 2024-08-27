using DecomposingComplexLINQEX.Domain;

namespace DecomposingComplexLINQEX.Presentation;

public static class HistogramUIExtensions
{
    public static void Show(this IDictionary<DateTime, int> histogram, DateTime cutoff, int barsCount)
    {
        (int high, int low) = (histogram.GetMaxValue(), histogram.GetMinValue());
        for (int h = high; h >= low; h--)
        {
            IEnumerable<string> pixels = Enumerable.Range(0, barsCount)
                .Select(i => histogram.GetHeight(cutoff.AddHours(i)))
                .Select(barHeight => barHeight >= h ? "#" : " ");
            Console.WriteLine(string.Join(' ', pixels).TrimEnd());
        }
        int width = 2 * barsCount - 1;
        Console.WriteLine(new string('-', width));
        Console.WriteLine("-48h" + "Now".PadLeft(width - "-48h".Length));
    }
}
