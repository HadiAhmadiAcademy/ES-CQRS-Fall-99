using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace Framework.Persistence.ES
{
    public static class StreamNames
    {
        public static string GetStreamName<T, TKey>(TKey id) where T : AggregateRoot<TKey>
        {
            var type = typeof(T).Name;
            return $"{type}-{id}";
        }
    }
}
