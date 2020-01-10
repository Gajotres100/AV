using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Application.Interfaces.Repositories;
using omProvis.CSP.Application.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Customers.Commands.ChangeMargin
{
    public class ChangeMarginCommand : ICommand
    {
        internal ChangeMarginModel ComandData { get; set; }

        public ChangeMarginCommand(ChangeMarginModel comandData)
        {
            ComandData = comandData;
        }

        internal sealed class ChangeMarginCommandHandler : ICommandHandler<ChangeMarginCommand>
        {
            private readonly ICustomerWriteRepository _customerWriteRepository;
            private readonly ICustomerReadRepository _customerReadRepository;
            public ChangeMarginCommandHandler(ICustomerWriteRepository customerWriteRepository,
                                                ICustomerReadRepository customerReadRepository)
            {
                _customerWriteRepository = customerWriteRepository;
                _customerReadRepository = customerReadRepository;
            }

            public async Task HandleAsync(ChangeMarginCommand command)
            {
                var customer = await _customerReadRepository.Get(command.ComandData.TenantId);

                if (customer == null)
                {
                    customer = new Domain.Customers.Customer
                    {
                        Id = command.ComandData.TenantId,
                        CreateDate = DateTime.Now,
                        Margin = command.ComandData.Data.Margin
                    };

                    await _customerWriteRepository.Add(customer);
                }
                else
                {
                    customer.Margin = command.ComandData.Data.Margin;
                    await _customerWriteRepository.Update(customer);
                }
            }
        }
    }
}
