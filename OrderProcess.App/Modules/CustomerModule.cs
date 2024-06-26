using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class CustomerModule
    {
        public static async void AddCustomerEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Customer");

            group.MapGet("/", async (ICustomerService customerService) => Results.Ok(await customerService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ICustomerService customerService) => {

                var customer = await customerService.GetById(id);

                if (customer == null) return Results.NotFound();

                return Results.Ok(customer);
            });

            group.MapGet("/custkey", async (string custkey, ICustomerService customerService) => {

                var customer = await customerService.GetByCustKey(custkey);

                if (customer == null) return Results.NotFound();

                return Results.Ok(customer);
            });


            group.MapPost("/", async (CustomerRequest request, ICustomerService customerService) =>
            {
                var newCustomer = await customerService.Create(request);
                return Results.Created($"api/Customer/{newCustomer.Id}", newCustomer);
            });
            group.MapPut("/{id:Guid}", async (Guid id, CustomerRequest request, ICustomerService customerService) => {

                var customer = await customerService.Update(id, request);
                return Results.Ok(customer);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ICustomerService customerService) =>
            {
                var success = await customerService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
