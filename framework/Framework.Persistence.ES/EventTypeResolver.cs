using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Framework.Domain;

namespace Framework.Persistence.ES
{
    public class EventTypeResolver : IEventTypeResolver
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();
        public void AddTypesFromAssembly(Assembly assembly)
        {
            var events = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(DomainEvent))).ToList();
            events.ForEach(a =>
            {
                _types.Add(a.Name, a);
            });
        }

        public Type GetType(string typeName)
        {
            if (_types.ContainsKey(typeName))
                return _types[typeName];
            return null;
        }
    }
}