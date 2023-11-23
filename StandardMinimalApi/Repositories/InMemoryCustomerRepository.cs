using CqsToCqrsMinimalApi.Entities;

namespace CqsToCqrsMinimalApi.Repositories
{
    public class InMemoryCustomerRepository
    {
        private static readonly List<Customer> customers = new List<Customer>();
        private int nextCustomerId = 1;

        // Get all customers
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        // Get customer by ID
        public Customer GetById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        // Add a new customer
        public void Add(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            customer.Id = nextCustomerId++;
            customers.Add(customer);
        }

        // Update an existing customer
        public void Update(int id, Customer updatedCustomer)
        {
            if (updatedCustomer == null)
            {
                throw new ArgumentNullException(nameof(updatedCustomer));
            }

            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
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
            var customerToRemove = customers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove != null)
            {
                customers.Remove(customerToRemove);
            }
        }
    }
}