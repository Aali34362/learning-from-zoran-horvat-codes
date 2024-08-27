namespace ResolveObjectTypeandMethods;

public class Base : ImplicitLayout
{
    public Base(TypeMetadata metadata) : base(metadata) { } // implicit
    internal static Type GetType(Base @this) => @this._metadata._type;
    internal static string WhoAmI(Base @this) => Base.GetType(@this).Name;
    internal static string WhatDoIDo(Base @this) => "I do stuff";
}

