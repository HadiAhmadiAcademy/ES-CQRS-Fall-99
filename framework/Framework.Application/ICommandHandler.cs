using System;
using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}
