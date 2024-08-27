namespace ResolveObjectTypeandMethods;

public static class Runtime
{
    public static T Call<T>(ImplicitLayout instance, string methodName, params object[] args)
    {
        virtual_function function = instance?._metadata?._vtable[methodName]!;   // Missing implementation
        object[] parameters = new object[] { instance! }.Concat(args).ToArray();
        return (T)function?.Invoke(parameters)!;                                 // Missing implementation
    }

    internal static Dictionary<string, virtual_function> Register<TType, T>(
        this Dictionary<string, virtual_function> vtable, string functionName, Func<TType, T> f)
    {
        vtable[functionName] = f.DynamicInvoke!;
        return vtable;
    }
}
