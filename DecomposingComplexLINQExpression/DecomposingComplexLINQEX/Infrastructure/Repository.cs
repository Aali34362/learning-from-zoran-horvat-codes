using DecomposingComplexLINQEX.Domain;

namespace DecomposingComplexLINQEX.Infrastructure;

public class Repository
{
    public IEnumerable<Usage> GetUsagesFromLatest(DateTime at)
    {
        Random rnd = new(Guid.NewGuid().GetHashCode());
        int stepSeconds = 240;
        int durationSeconds = 620;
        DateTime time = at;
        while(true)
        {
            time -= TimeSpan.FromSeconds(rnd.NextDouble() * stepSeconds);
            DateTime lastSeen = time + TimeSpan.FromSeconds(rnd.NextDouble() * durationSeconds);
            yield return new(time, lastSeen);
        }
    }
}
