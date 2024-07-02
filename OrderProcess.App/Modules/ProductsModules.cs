using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class ProductsModules
    {
        public static async void AddProductsEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Products");

            group.MapGet("/", async (IProductsService productsService) => Results.Ok(await productsService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IProductsService productsService) => {

                var product = await productsService.GetById(id);

                if (product == null) return Results.NotFound();

                return Results.Ok(product);
            });


            group.MapPost("/", async (ProductsRequest request, IProductsService productsService) =>
            {
                var product = await productsService.Create(request);
                return Results.Created($"api/Products/{product.Id}", product);
            });
            group.MapPut("/{id:Guid}", async (Guid id, ProductsRequest request, IProductsService productsService) => {

                var product = await productsService.Update(id, request);
                return Results.Ok(product);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IProductsService productsService) =>
            {
                var success = await productsService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
