using Framework.Domain;
using Framework.Persistence.ES.Mappings.Builders;
using Framework.Persistence.ES.Mappings.Filters;

namespace Framework.Persistence.ES.Mappings
{
    public abstract class SchemaMapping<T> : ISchemaMapping where T : DomainEvent
    {
        public IFilter CreateFilter()
        {
            var builder = CreateFilterBuilder();
            Configure(builder);
            return builder.Build();
        }
        private static FilterBuilder CreateFilterBuilder()
        {
            return new FilterBuilder();
        }
        protected abstract void Configure(IFilterBuilder builder);
    }

}