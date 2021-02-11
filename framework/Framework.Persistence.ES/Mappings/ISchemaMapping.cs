using Framework.Persistence.ES.Mappings.Filters;

namespace Framework.Persistence.ES.Mappings
{
    public interface ISchemaMapping
    {
        IFilter CreateFilter();
    }
}