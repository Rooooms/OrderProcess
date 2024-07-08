using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class CustomerScopeModule
    {
        public static async void AddCustomerScopeEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/customerscope");

            group.MapGet("/", async (ICustomerScopeService customerScopeService) => Results.Ok(await customerScopeService.GetAll()));

  

            group.MapPost("/", async (CustomerScopeRequest request, ICustomerScopeService customerScopeService) =>
            {
                var customerScope = await customerScopeService.Create(request);
                return Results.Created($"api/customerscope/{customerScope.Id}", customerScope);
            });
            group.MapPut("/{id:Guid}", async (Guid id, CustomerScopeRequest request, ICustomerScopeService customerScopeService) => {

                var customerScope = await customerScopeService.Update(id, request);
                return Results.Ok(customerScope);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ICustomerScopeService customerScopeService) =>
            {
                var success = await customerScopeService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
