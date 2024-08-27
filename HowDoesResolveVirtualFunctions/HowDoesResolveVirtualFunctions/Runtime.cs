namespace HowDoesResolveVirtualFunctions;

public static class Runtime
{
    public static T Call<T>(ImplicitLayout instance, string methodName, params object[] args)
    {
        virtual_function function = instance._metadata._vtable[methodName];
        return (T)function.Invoke(args);
    }
}
