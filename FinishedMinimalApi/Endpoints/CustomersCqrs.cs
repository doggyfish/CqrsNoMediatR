using CqsToCqrsMinimalApi.Entities;
using CqsToCqrsMinimalApi.Repositories;
using StandardMinimalApi.Cqrs;

namespace CqsToCqrsMinimalApi.Endpoints
{
    public static class CustomersCqrs
    {
        public static void AddCustomersCqrsEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/customers", (CustomersReadRepository repository) =>
            {
                return Results.Ok(repository.Get());
            });

            builder.MapGet("/customers/{id}", (CustomersReadRepository repository, int id) =>
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

            builder.MapPost("/customers", (CustomersWriteRepository repository, Customer newCustomer) =>
            {
                if (newCustomer == null)
                {
                    return Results.BadRequest("Invalid customer data");
                }

                repository.Add(newCustomer);
                return Results.Created($"/customers/{newCustomer.Id}", newCustomer);
            });

            builder.MapPut("/customers/{id}", (CustomersWriteRepository repository, int id, Customer updatedCustomer) =>
            {
                if (updatedCustomer == null)
                {
                    return Results.BadRequest("Invalid customer data");
                }

                repository.Update(id, updatedCustomer);

                return Results.Ok(updatedCustomer);
            });

            builder.MapDelete("/customers/{id}", (CustomersWriteRepository repository, int id) =>
            {
                repository.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
