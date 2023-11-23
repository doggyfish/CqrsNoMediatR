using CqsToCqrsMinimalApi.Cqrs;
using CqsToCqrsMinimalApi.Entities;

namespace StandardMinimalApi.CqrsTowardsMediatR
{
    public class GetCustomerByIdQuery
    {
        public Customer Handle(int id)
        {
            return BaseRepository.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
