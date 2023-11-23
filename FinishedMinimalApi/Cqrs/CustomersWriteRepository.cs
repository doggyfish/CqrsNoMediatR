using CqsToCqrsMinimalApi.Cqrs;
using CqsToCqrsMinimalApi.Entities;

namespace StandardMinimalApi.Cqrs
{
    public class CustomersWriteRepository
    {
        private int nextCustomerId = 1;

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

        // Update an existing customer
        public void Update(int id, Customer updatedCustomer)
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

        // Delete a customer by ID
        public void Delete(int id)
        {
            var customerToRemove = BaseRepository.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove != null)
            {
                BaseRepository.Customers.Remove(customerToRemove);
            }
        }
    }
}
