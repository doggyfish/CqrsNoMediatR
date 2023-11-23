using CqsToCqrsMinimalApi.Cqrs;

namespace StandardMinimalApi.CqrsTowardsMediatR
{
    public class DeleteCustomerCommand
    {
        // Delete a customer by ID
        public void Handle(int id)
        {
            var customerToRemove = BaseRepository.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove != null)
            {
                BaseRepository.Customers.Remove(customerToRemove);
            }
        }
    }
}
