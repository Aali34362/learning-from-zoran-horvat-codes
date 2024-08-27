using HowDoesResolveVirtualFunctions;

Report(new Base());
Report(new Derived());

void Report(Base x) => Console.WriteLine(
    $"{x.WhoAmI().PadLeft(10)} - {Runtime.Call<string>(x, "WhatDoIDo")}");
