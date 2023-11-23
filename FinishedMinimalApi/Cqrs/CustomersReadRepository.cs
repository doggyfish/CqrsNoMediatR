using CqsToCqrsMinimalApi.Cqrs;
using CqsToCqrsMinimalApi.Entities;

namespace StandardMinimalApi.Cqrs
{
    public class CustomersReadRepository
    {
        public IEnumerable<Customer> Get()
        {
            return BaseRepository.Customers;
        }

        // Get customer by ID
        public Customer GetById(int id)
        {
            return BaseRepository.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
