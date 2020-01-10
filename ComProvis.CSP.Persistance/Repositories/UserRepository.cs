using ComProvis.CSP.Application.Interfaces.Repositories;
using D = ComProvis.CSP.Domain.Customers;
using E = ComProvis.CSP.Persistance.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;

namespace ComProvis.CSP.Persistance.Repositories
{
    public class UserRepository : IUserReadRepository, IUserWriteRepository
    {
        internal ICspDbContext _cspDbContext;
        private readonly IMapper _mapper;
        public UserRepository(ICspDbContext cspDbContext, IMapper mapper)
        {
            _cspDbContext = cspDbContext;
            _mapper = mapper;
        }

        public async Task Add(D.User user)
        {
            var customer = await _cspDbContext.Customer.FirstOrDefaultAsync(x => x.Guid == user.CustomerId);
            var role = await _cspDbContext.Role.FirstOrDefaultAsync(x => x.Id == user.RoleId);

            var userData = _mapper.Map<E.User>(user);
            userData.Customer = customer;

            _cspDbContext.User.Add(userData);
            await _cspDbContext.SaveChangesAsync();
        }

        public async Task<D.User> Get(Guid id) => _mapper.Map<D.User>(await _cspDbContext.User.FirstOrDefaultAsync(x => x.Guid == id));

        public async Task Update(D.User user)
        {
            var userData = await _cspDbContext.User.FirstOrDefaultAsync(x => x.Guid == user.Id);
            userData.Password = user.Password;
            _cspDbContext.User.Update(userData);
            await _cspDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
        }

        public async Task<D.User> AuteticateUser(string username, string password) => _mapper.Map<D.User>(await _cspDbContext.User.FirstOrDefaultAsync(x => x.Username.Equals(username) && x.Password.Equals(password)));

        public async Task<D.User> GetByUsername(string username)
        {
            var user = await _cspDbContext.User.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null) return null;

            var customer = await _cspDbContext.Customer.FirstOrDefaultAsync(x => x.Id == user.CustomerId);

            var domainUser= _mapper.Map<D.User>(await _cspDbContext.User.FirstOrDefaultAsync(x => x.Username == username));
            domainUser.CustomerId = customer.Guid.GetValueOrDefault();
            return domainUser;
        }

        public async Task<D.User> GetFirstByCustomerId(Guid customerId) => _mapper.Map<D.User>(await _cspDbContext.User.FirstOrDefaultAsync(x => x.Customer.Guid == customerId));
    }
}
