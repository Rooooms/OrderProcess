using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class CustomerDetailsModule
    {
        public static async void AddCustomerDetailsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/CustomerDetails");

            group.MapGet("/", async (ICustomerDetailsService customerDetailsService) => Results.Ok(await customerDetailsService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ICustomerDetailsService customerDetailsService) => {

                var customerDetails = await customerDetailsService.GetById(id);

                if (customerDetails == null) return Results.NotFound();

                return Results.Ok(customerDetails);
            });

            group.MapGet("/custkey", async (string custkey, ICustomerDetailsService customerDetailsService) => {

                var customerDetails = await customerDetailsService.GetByCustKey(custkey);

                if (customerDetails == null) return Results.NotFound();

                return Results.Ok(customerDetails);
            });


            group.MapPost("/", async (CustomerDetailsRequest request, ICustomerDetailsService customerDetailsService) =>
            {
                var newCustomerDetails = await customerDetailsService.Create(request);
                return Results.Created($"api/CustomerDetails/{newCustomerDetails.Id}", newCustomerDetails);
            });
            group.MapPut("/{id:Guid}", async (Guid id, CustomerDetailsRequest request, ICustomerDetailsService customerDetailsService) => {

                var customerDetails = await customerDetailsService.Update(id, request);
                return Results.Ok(customerDetails);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ICustomerDetailsService customerDetailsService) =>
            {
                var success = await customerDetailsService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
