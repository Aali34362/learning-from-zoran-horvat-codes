// See https://aka.ms/new-console-template for more information
using DecomposingComplexLINQEX.Domain;
using DecomposingComplexLINQEX.Infrastructure;
using DecomposingComplexLINQEX.Presentation;

Console.WriteLine("Hello, World!");
DateTime now = DateTime.UtcNow.Date.AddHours(10);
int maxAgeHours = 48;
DateTime cutoff = now.AddHours(-maxAgeHours);

new Repository()
    .GetTimeWindow(cutoff, now)
    .GetHourlyHistogram()
    .Show(cutoff, maxAgeHours);
