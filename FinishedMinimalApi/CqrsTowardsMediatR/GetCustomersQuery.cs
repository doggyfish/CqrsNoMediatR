using CqsToCqrsMinimalApi.Cqrs;
using CqsToCqrsMinimalApi.Entities;

namespace StandardMinimalApi.CqrsTowardsMediatR
{
    public class GetCustomersQuery
    {
        public IEnumerable<Customer> Handle()
        {
            return BaseRepository.Customers;
        }
    }
}
