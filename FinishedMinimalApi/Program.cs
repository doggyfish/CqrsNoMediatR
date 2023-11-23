using CqsToCqrsMinimalApi.Endpoints;
using CqsToCqrsMinimalApi.Repositories;
using StandardMinimalApi.Cqrs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<InMemoryCustomerRepository>();
builder.Services.AddSingleton<CustomersWriteRepository>();
builder.Services.AddSingleton<CustomersReadRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddCustomersEndpoints();

app.Run();

