using EventStore.ClientAPI;

namespace LoanManagement.Projections.Sql.Framework
{
    public interface ICursor
    {
        Position CurrentPosition();
        void MoveTo(Position position);
    }
}