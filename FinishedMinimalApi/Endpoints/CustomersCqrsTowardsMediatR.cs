using CqsToCqrsMinimalApi.Entities;
using CqsToCqrsMinimalApi.Repositories;
using StandardMinimalApi.Cqrs;
using StandardMinimalApi.CqrsTowardsMediatR;

namespace CqsToCqrsMinimalApi.Endpoints
{
    public static class CustomersCqrsMediatR
    {
        public static void AddCustomersCqrsMediatREndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/customers", () =>
            {
                return Results.Ok(new GetCustomersQuery().Handle());
            });

            builder.MapGet("/customers/{id}", (int id) =>
            {
                var customer = new GetCustomerByIdQuery().Handle(id);
                if (customer != null)
                {
                    return Results.Ok(customer);
                }
                else
                {
                    return Results.NotFound($"Customer with ID {id} not found");
                }
            });

            builder.MapPost("/customers", (Customer newCustomer) =>
            {
                if (newCustomer == null)
                {
                    return Results.BadRequest("Invalid customer data");
                }

                new AddCustomerCommand().Handle(newCustomer);

                return Results.Created($"/customers/{newCustomer.Id}", newCustomer);
            });

            builder.MapPut("/customers/{id}", (int id, Customer updatedCustomer) =>
            {
                if (updatedCustomer == null)
                {
                    return Results.BadRequest("Invalid customer data");
                }

                new UpdateCustomerCommand().Handle(id, updatedCustomer);

                return Results.Ok(updatedCustomer);
            });

            builder.MapDelete("/customers/{id}", (int id) =>
            {
                new DeleteCustomerCommand().Handle(id);
                return Results.NoContent();
            });
        }
    }
}
