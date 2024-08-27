using ResolveObjectTypeandMethods;

Report(new Base(null!));
Report(new Derived(null!));

static void Report(Base x) => Console.WriteLine(
    $"{(Runtime.Call<string>(x, "WhoAmI") ?? "N/A").PadLeft(10)} - {Runtime.Call<string>(x, "WhatDoIDo") ?? "N/A"}");
