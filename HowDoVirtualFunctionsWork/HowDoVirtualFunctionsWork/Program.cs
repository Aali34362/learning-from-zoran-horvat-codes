using HowDoVirtualFunctionsWork;

Report(new Base());
Report(new Derived());

void Report(Base x) =>
    Console.WriteLine($"{x.WhoAmI().PadLeft(10)} - {x.WhatDoIDo()}");