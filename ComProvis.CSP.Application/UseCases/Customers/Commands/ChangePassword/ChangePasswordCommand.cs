using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Application.Interfaces.Repositories;
using ComProvis.CSP.Common;
using ComProvis.CSP.Domain.Customers;
using omProvis.CSP.Application.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Customers.Commands.ChangePassword
{
    public class ChangePasswordCommand : ICommand
    {
        internal ChangePasswordModel ComandData { get; set; }

        public ChangePasswordCommand(ChangePasswordModel data)
        {
            ComandData = data;
        }

        internal sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
        {
            private readonly ICustomerWriteRepository _customerWriteRepository;
            private readonly ICustomerReadRepository _customerReadRepository;
            private readonly IUserWriteRepository _userWriteRepository;
            private readonly IUserReadRepository _userReadRepository;
            private readonly IMapper _mapper;
            public ChangePasswordCommandHandler(ICustomerWriteRepository customerWriteRepository, 
                                                ICustomerReadRepository customerReadRepository,
                                                IUserWriteRepository userWriteRepository,
                                                IUserReadRepository userReadRepository,
                                                IMapper mapper)
            {
                _customerWriteRepository = customerWriteRepository;
                _customerReadRepository = customerReadRepository;
                _userWriteRepository = userWriteRepository;
                _userReadRepository = userReadRepository;

                _mapper = mapper;
            }

            public async Task HandleAsync(ChangePasswordCommand command)
            {
                var customerDomain = _mapper.Map<Customer>(command.ComandData);
                var customer = await _customerReadRepository.Get(command.ComandData.TenantId);

                if (customer == null)
                    await _customerWriteRepository.Add(customerDomain);                                

                var user = await _userReadRepository.GetByUsername(command.ComandData.Data.Username);
                var userDomain = new User
                {
                    Id = user == null ? Guid.NewGuid() : user.Id,
                    CustomerId = command.ComandData.TenantId,
                    Username = command.ComandData.Data.Username,
                    RoleId = (int)Common.Enums.Roles.Local,
                    Password = MD5.CreateMD5(command.ComandData.Data.Password)
                };

                if (user == null)
                    await _userWriteRepository.Add(userDomain);
                else
                    await _userWriteRepository.Update(userDomain);
            }
        }
    }
}
