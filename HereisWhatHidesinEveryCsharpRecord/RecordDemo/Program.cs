// See https://aka.ms/new-console-template for more information
using RecordDemo.Record_class;
using RecordDemo.Traditional_class;
using System;

Console.WriteLine("Hello, World!");

//Traditional Class
PersonNormalClass joe = new("Joe", new(1997, 4, 28));
Console.WriteLine(joe);

IEnumerable<PersonNormalClass> people = new PersonNormalClass[]
{
    new("Joe", new(1997, 4, 28)),
    new("Jane", new(1982, 5, 14)),
    new("Joe", new(1986, 7, 19)),
    new("Joe", new(1997, 4, 28)),
    new("Jane", new(1982, 5, 14)),
};
Console.WriteLine($"Total {people.Count()}; distinct {people.Distinct().Count()}");

var repeats = people.GroupBy(x => x).Select(g => (g.Key, g.Count()));
foreach ((PersonNormalClass person, int count) in repeats)
{
    Console.WriteLine($"{count} x {person}");
}

//Record Class
PersonRecord joe1 = new("Joe", new(1997, 4, 28));
Console.WriteLine(joe1);

IEnumerable<PersonRecord> peoples = new PersonRecord[]
{
    new("Joe", new(1997, 4, 28)),
    new("Jane", new(1982, 5, 14)),
    new("Joe", new(1986, 7, 19)),
    new("Joe", new(1997, 4, 28)),
    new("Jane", new(1982, 5, 14)),
};
Console.WriteLine($"Total {peoples.Count()}; distinct {peoples.Distinct().Count()}");

var repeats1 = peoples.GroupBy(x => x).Select(g => (g.Key, g.Count()));
foreach ((PersonRecord person1, int count) in repeats1)
{
    Console.WriteLine($"{count} x {person1}");
}