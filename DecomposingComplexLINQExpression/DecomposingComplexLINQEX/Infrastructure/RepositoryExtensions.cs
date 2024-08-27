using DecomposingComplexLINQEX.Domain;

namespace DecomposingComplexLINQEX.Infrastructure;

public static class RepositoryExtensions
{
    public static IEnumerable<Usage> GetTimeWindow(this Repository repository, DateTime cutoff, DateTime before) =>
        repository.GetUsagesFromLatest(before)
            .TakeWhile(sample => sample.Started >= cutoff);
}
