namespace HowDoVirtualFunctionsWork;

public class Base
{
    public virtual string WhoAmI() => this.GetType().Name;
    public virtual string WhatDoIDo() => "I do stuff";
}

