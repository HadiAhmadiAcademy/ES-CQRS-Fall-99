using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Filters
{
    public interface IFilter
    {
        void SetNext(IFilter next);
        JObject Apply(JObject json);
    }
}