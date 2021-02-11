using System.Threading.Tasks;

namespace Framework.Core.Events
{
    public interface IEventBus
    {
        Task Publish<T>(T eventToPublish) where T : IEvent;
    }
}