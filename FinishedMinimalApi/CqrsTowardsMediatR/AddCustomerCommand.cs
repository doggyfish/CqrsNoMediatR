using CqsToCqrsMinimalApi.Cqrs;
using CqsToCqrsMinimalApi.Entities;

namespace StandardMinimalApi.CqrsTowardsMediatR
{
    public class AddCustomerCommand
    {
        private int nextCustomerId = 1;

        /*
         * Rename Add to Handle
         */
        
        
        // Add a new customer
        public void Add(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            customer.Id = nextCustomerId++;
            BaseRepository.Customers.Add(customer);
        }

        public void Handle(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            customer.Id = nextCustomerId++;
            BaseRepository.Customers.Add(customer);
        }
    }
}
