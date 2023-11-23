using CqsToCqrsMinimalApi.Entities;
using CqsToCqrsMinimalApi.Repositories;

namespace CqsToCqrsMinimalApi.Endpoints
{
    public static class Customers
    {
        public static void AddCustomersEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/customers", (InMemoryCustomerRepository repository) =>
            {
                return Results.Ok(repository.Get());
            });

            builder.MapGet("/customers/{id}", (InMemoryCustomerRepository repository, int id) =>
            {
                var customer = repository.GetById(id);
                if (customer != null)
                {
                    return Results.Ok(customer);
                }
                else
                {
                    return Results.NotFound($"Customer with ID {id} not found");
                }
            });

            builder.MapPost("/customers", (InMemoryCustomerRepository repository, Customer newCustomer) =>
            {
                if (newCustomer == null)
                {
                    return Results.BadRequest("Invalid customer data");
                }

                repository.Add(newCustomer);
                return Results.Created($"/customers/{newCustomer.Id}", newCustomer);
            });

            builder.MapPut("/customers/{id}", (InMemoryCustomerRepository repository, int id, Customer updatedCustomer) =>
            {
                var existingCustomer = repository.GetById(id);
                if (existingCustomer == null)
                {
                    return Results.NotFound($"Customer with ID {id} not found");
                }

                if (updatedCustomer == null)
                {
                    return Results.BadRequest("Invalid customer data");
                }

                // Update the customer
                existingCustomer.Name = updatedCustomer.Name;
                existingCustomer.Email = updatedCustomer.Email;

                return Results.Ok(existingCustomer);
            });

            builder.MapDelete("/customers/{id}", (InMemoryCustomerRepository repository, int id) =>
            {
                var customerToDelete = repository.GetById(id);
                if (customerToDelete == null)
                {
                    return Results.NotFound($"Customer with ID {id} not found");
                }

                repository.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
