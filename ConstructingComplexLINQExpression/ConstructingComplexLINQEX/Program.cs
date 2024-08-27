// See https://aka.ms/new-console-template for more information

Console.WriteLine("Sample data:");
foreach (var sample in new Repository().GetUsagesFromLatest(DateTime.UtcNow.Date).Take(10))
    Console.WriteLine(sample);
Console.WriteLine(new string('-', 80));

Console.WriteLine();
Console.WriteLine("Histogram:");
DateTime now = DateTime.UtcNow.Date.AddHours(10);
int maxAgeHours = 12;

DateTime cutoff = now.AddHours(-maxAgeHours);

new Repository()
    .GetUsagesFromLatest(now)
    .TakeWhile(sample => sample.Started >= cutoff)                              // Infrastructure

    .Select(sample => (int)Math.Ceiling((now - sample.Started).TotalHours))     // Domain
    .GroupBy(age => age)
    .Select(group => (hour: now.AddHours(-group.Key), age: group.Key, count: group.Count()))

    .OrderByDescending(row => row.age)                                          // UI
    .Select(row => $"{row.hour:yyyy/MM/dd HH\\:00\\:00} {new string('*', row.count)}")
    .WriteLines();

static class ConsoleExtensions
{
    public static void WriteLines(this IEnumerable<string> lines)
    {
        foreach (string line in lines)
            Console.WriteLine(line);
    }
}

public record Usage(DateTime Started, DateTime LastSeen);

class Repository
{
    public IEnumerable<Usage> GetUsagesFromLatest(DateTime at)
    {
        Random rnd = new(Guid.NewGuid().GetHashCode());
        int stepSeconds = 280;
        int durationSeconds = 1200;
        DateTime time = at;
        while (true)
        {
            time -= TimeSpan.FromSeconds(rnd.NextDouble() * stepSeconds);
            DateTime lastSeen = time + TimeSpan.FromSeconds(rnd.NextDouble() * durationSeconds);
            yield return new(time, lastSeen);
        }
    }
}



















/*
 Extension:
In C#, extension methods allow you to "extend" existing types with new methods without modifying the original type. 
These methods are defined in static classes and are marked with the this keyword before the first parameter.
The type of the first parameter is the type you want to extend, 
and any instance of that type can call the extension method as if it were a method on the type itself.

static class ConsoleExtensions: 
This is a static class that will hold your extension methods.

public static void WriteLines(this IEnumerable<string> lines): 
This is the extension method. The this keyword before IEnumerable<string> tells the compiler that this method
is an extension method for any object that implements IEnumerable<string>. 
This means you can call WriteLines() on any IEnumerable<string> as if it were a method of that type.

WriteLines() is called at the end of a chain of LINQ method calls.
How It Fits In:
The .Select(...) methods in the chain return an IEnumerable<string>, where each string represents a formatted line of output.
The WriteLines method is an extension method that operates on IEnumerable<string>. 
Because this IEnumerable<string> is the first parameter in the WriteLines method, you can call it directly on the result of the Select method.

How Extension Methods Work

Definition: 
You define an extension method in a static class. 
The method itself must also be static, and the first parameter 
must be prefixed with this, which tells the compiler that this method 
is an extension method for the type of the first parameter.

Usage: 
Once defined, you can call the extension method on any instance of 
the type you're extending as if it were a method of that type. 
The compiler will translate this to a call to your static method.

Benefits of Extension Methods
Non-Intrusive: You don't need to modify the original type to add new functionality.
Readability: Extension methods can make code more readable by allowing method chaining.
Encapsulation: You can group related methods into a static class, promoting better organization.

Conclusion
In your example, the WriteLines method is an extension of IEnumerable<string>. 
When you call it at the end of your LINQ chain, you're using this extension method to write each formatted string 
(representing usage data) to the console. The WriteLines method fits in because 
it operates on the result of the Select method, which returns an IEnumerable<string>.

 */