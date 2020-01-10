using ComProvis.CSP.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.Utils
{
    public sealed class Messages : IMessages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task DispatchAsync(ICommand command)
        {
            var type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            await handler.HandleAsync((dynamic)command);
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query)
        {
            var type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            var result = await handler.HandleAsync((dynamic)query);
            return result;
        }
    }
}
