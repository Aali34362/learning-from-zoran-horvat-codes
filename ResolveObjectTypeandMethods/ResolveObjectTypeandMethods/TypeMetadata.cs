namespace ResolveObjectTypeandMethods;

public class TypeMetadata
{
    internal Dictionary<string, virtual_function> _vtable;
    internal Type _type;
}

delegate object virtual_function(params object[] args);