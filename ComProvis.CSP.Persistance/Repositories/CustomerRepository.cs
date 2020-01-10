using AutoMapper;
using ComProvis.CSP.Application.Interfaces.Repositories;
using D = ComProvis.CSP.Domain.Customers;
using omProvis.CSP.Application.Interfaces.Repository;
using System;
using System.Threading.Tasks;
using E = ComProvis.CSP.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComProvis.CSP.Persistance.Repositories
{
    public class CustomerRepository : ICustomerReadRepository, ICustomerWriteRepository
    {
        internal ICspDbContext _cspDbContext;
        private readonly IMapper _mapper;
        public CustomerRepository(ICspDbContext cspDbContext, IMapper mapper)
        {
            _cspDbContext = cspDbContext;
            _mapper = mapper;
        }

        public async Task Add(D.Customer customer)
        {
             _cspDbContext.Customer.Add(_mapper.Map<E.Customer>(customer));
            await _cspDbContext.SaveChangesAsync();
        }

        public async Task<D.Customer> Get(Guid id) => _mapper.Map<D.Customer>(await _cspDbContext.Customer.FirstOrDefaultAsync(x => x.Guid == id));

        public async Task Update(D.Customer customer)
        {
            var customerData = await _cspDbContext.Customer.FirstOrDefaultAsync(x => x.Guid == customer.Id);
            customerData.Margin = customer.Margin;
            _cspDbContext.Customer.Update(customerData);
            await _cspDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
        }
    }
}
