namespace HowDoesResolveVirtualFunctions;


public class Base : ImplicitLayout
{
    public Base() : base() // implicit
    {
        Register<string>("WhatDoIDo", () => "I do stuff");
    }
    // _metadata comes here
    public virtual string WhoAmI() => this.GetType().Name;
}
