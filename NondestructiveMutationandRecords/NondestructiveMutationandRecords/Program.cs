using NondestructiveMutationandRecords.TraditionalClass;
using NondestructiveMutationandRecords.UsingInitSetters;
using System;

///Traditional 
TraditionalPerson joe = new() { Name = "Joe", Age = 28 };
TraditionalPerson jim = joe with { Name = "Jim" };

Console.WriteLine("Using records:");
Console.Out.TraditionalWriteLines(joe, jim);

TraditionalCommonPerson commonJoe = new() { Name = "Joe", Age = 28 };
TraditionalCommonPerson commonJim = new(commonJoe.Name, commonJoe.Age) { Name = "Jim" };
TraditionalCommonPerson commonJill = commonJoe.WithName("Jill");

Console.WriteLine(new string('-', 80));
Console.WriteLine();
Console.WriteLine("Using custom classes:");
Console.Out.TraditionalWriteLines(commonJoe, commonJim, commonJill);

///Using Init Setters 
InitSettersPerson isjoe = new() { Name = "Joe", Age = 28 };
InitSettersPerson isjim = isjoe with { Name = "Jim" };
InitSettersPerson isjill = isjoe with { Name = "Jill" };
InitSettersPerson isjake = isjoe with { Name = "Jake" };

Console.WriteLine("Using records:");
Console.Out.InitSettersWriteLines(isjoe, isjim, isjill, isjake);

InitSettersPerson child = new() { Name = string.Empty, Age = 14 };
InitSettersPerson[] schoolClass = new[]
{
    child with { Name = "John" },
    child with { Name = "Jane" },
    child with { Name = "Jack" },
    child with { Name = "Jill" },
};

Console.WriteLine("Array of records:");
Console.Out.InitSettersWriteLines(schoolClass);

InitSettersCommonPerson iscommonJoe = new() { Name = "Joe", Age = 28 };
InitSettersCommonPerson iscommonJim = new(iscommonJoe.Name, iscommonJoe.Age) { Name = "Jim" };
InitSettersCommonPerson iscommonJill = iscommonJoe.WithName("Jill");
InitSettersCommonPerson iscommonJake = new(iscommonJoe) { Name = "Jake" };

Console.WriteLine(new string('-', 80));
Console.WriteLine();
Console.WriteLine("Using custom classes:");
Console.Out.InitSettersWriteLines(iscommonJoe, iscommonJim, iscommonJill, iscommonJake);

InitSettersCommonPerson commonChild = new() { Name = string.Empty, Age = 14 };
InitSettersCommonPerson[] commonSchoolClass = new InitSettersCommonPerson[]
{
    new(commonChild) { Name = "John" },
    new(commonChild) { Name = "Jane" },
    new(commonChild) { Name = "Jack" },
    new(commonChild) { Name = "Jill" },
};
Console.WriteLine("Array of custom classes:");
Console.Out.InitSettersWriteLines(commonSchoolClass);