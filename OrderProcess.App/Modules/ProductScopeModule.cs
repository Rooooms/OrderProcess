using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class ProductScopeModule
    {
        public static async void AddProductScopeEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/productscope");

            group.MapGet("/", async (IProductScopeService productScopeService) => Results.Ok(await productScopeService.GetAll()));



            group.MapPost("/", async (ProductScopeRequest request, IProductScopeService productScopeService) =>
            {
                var productScope = await productScopeService.Create(request);
                return Results.Created($"api/productscope/{productScope.Id}", productScope);
            });
            group.MapPut("/{id:Guid}", async (Guid id, ProductScopeRequest request, IProductScopeService productScopeService) => {

                var productScope = await productScopeService.Update(id, request);
                return Results.Ok(productScope);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IProductScopeService productScopeService) =>
            {
                var success = await productScopeService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
