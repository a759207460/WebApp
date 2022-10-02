using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Data;

namespace Nop.Services.Customers
{
    public partial class CustomerService : ICustomerService
    {

        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository) {
            _customerRepository = customerRepository;
        }
        public Customer GetCustomerById(int customerId)
        {
            if (customerId == 0)
                return null;
            return _customerRepository.GetById(customerId);
        }
    }
}
