namespace Framework.Persistence.ES.Mappings.Builders
{
    public interface IConditionFilterBuilder
    {
        IOperationFilterBuilder WhenAbsent(string propertyName);
    }
}