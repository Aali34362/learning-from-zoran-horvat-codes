namespace DecomposingComplexLINQEX.Domain;

public static class Histogram
{
    public static IDictionary<DateTime, int> GetHourlyHistogram(this IEnumerable<Usage> samples) =>
        samples.Select(samples => samples.Started)
        .GroupBy(time=>time.Date.AddHours(time.Hour))
        .ToDictionary(group=> group.Key, group => group.Count());

    public static int GetMinValue(this IDictionary<DateTime, int> histogram) =>
        histogram.Values.Min();

    public static int GetMaxValue(this IDictionary<DateTime, int> histogram) =>
        histogram.Values.Max();

    public static int GetHeight(this IDictionary<DateTime, int> histogram, DateTime key) =>
        histogram.TryGetValue(key, out int known) ? known : 0;

}
 