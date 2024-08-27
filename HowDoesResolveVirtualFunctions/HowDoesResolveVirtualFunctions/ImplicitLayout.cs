namespace HowDoesResolveVirtualFunctions;

public class ImplicitLayout
{
    internal TypeMetadata _metadata = new();

    protected void Register<T>(string functionName, Func<T> f) =>
        _metadata._vtable[functionName] = f.DynamicInvoke!;
}
