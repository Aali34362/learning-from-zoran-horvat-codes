namespace ResolveObjectTypeandMethods;

public class Derived : Base
{
    public Derived(TypeMetadata metadata) : base(metadata) { } // implicit
    internal static string WhatDoIDo(Derived @this) => "I can do more";
}

