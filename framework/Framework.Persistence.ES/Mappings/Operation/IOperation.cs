using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Operation
{
    internal interface IOperation
    {
        JObject Apply(JObject json);
    }
}