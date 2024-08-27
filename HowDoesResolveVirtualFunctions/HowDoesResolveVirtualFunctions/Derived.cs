namespace HowDoesResolveVirtualFunctions;

public class Derived : Base
{
    public Derived() : base() // implicit
    {
        Register<string>("WhatDoIDo", () => "I can do more");
    }
    // _metadata comes here
    // WhoAmI() exists here
}

