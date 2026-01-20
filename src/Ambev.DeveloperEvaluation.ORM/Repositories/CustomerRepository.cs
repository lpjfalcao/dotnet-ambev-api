using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly DefaultContext _context;
        public CustomerRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerSalesInfo(Guid id)
        {
            return await _context.Customers
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderItems)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
