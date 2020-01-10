using System.Threading.Tasks;

namespace ComProvis.CSP.Application.Interfaces
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
    where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
