using System;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;

namespace LoanManagement.TestProjection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@192.168.39.31:1113"));
            await conn.ConnectAsync();
            //var position = new Position(255363, 255363);
            conn.SubscribeToAllFrom(Position.Start, CatchUpSubscriptionSettings.Default, EventAppeared);

            Console.WriteLine("Subscribed !");
            Console.ReadLine();
        }

        private static async Task EventAppeared(EventStoreCatchUpSubscription arg1, ResolvedEvent arg2)
        {
            if (arg2.Event.EventType.StartsWith("$")) return;

            var eventBody = Encoding.UTF8.GetString(arg2.Event.Data);
            Console.WriteLine(arg2.Event.EventType);
            Console.WriteLine($"Position : {arg2.OriginalPosition.Value}");
            Console.WriteLine(eventBody);
            Console.WriteLine("--------------------------------");
        }
    }
}
