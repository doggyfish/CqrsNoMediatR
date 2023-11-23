using CqsToCqrsMinimalApi.Cqrs;
using CqsToCqrsMinimalApi.Entities;

namespace StandardMinimalApi.CqrsTowardsMediatR
{
    public class UpdateCustomerCommand
    {
        // Update an existing customer
        public void Handle(int id, Customer updatedCustomer)
        {
            if (updatedCustomer == null)
            {
                throw new ArgumentNullException(nameof(updatedCustomer));
            }

            var existingCustomer = BaseRepository.Customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;
        }
    }
}
