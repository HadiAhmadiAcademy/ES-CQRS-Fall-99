using System;
using System.Reflection;

namespace Framework.Persistence.ES
{
    public interface IEventTypeResolver
    {
        void AddTypesFromAssembly(Assembly assembly);
        Type GetType(string typeName);
    }
}