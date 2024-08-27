namespace HowDoesResolveVirtualFunctions;

class TypeMetadata
{
    internal Dictionary<string, virtual_function> _vtable = new();
}

delegate object virtual_function(params object[] args);