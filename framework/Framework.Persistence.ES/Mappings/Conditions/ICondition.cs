using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Conditions
{
    internal interface ICondition
    {
        string PropertyName { get; }
        bool IsSatisfied(JObject json);
    }
}