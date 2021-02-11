using EventStore.ClientAPI;

namespace LoanManagement.Projections.Sql.Framework
{
    public class FakeCursor : ICursor
    {
        public Position CurrentPosition()
        {
            return Position.Start;
        }

        public void MoveTo(Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}