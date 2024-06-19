using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class ProductModule
    {
        public static async void AddProductEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Product");

            group.MapGet("/", async (IProductService productService) => Results.Ok(await productService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IProductService productService) => {

                var product = await productService.GetById(id);

                if (product == null) return Results.NotFound();

                return Results.Ok(product);
            });


            group.MapPost("/", async (ProductRequest request, IProductService productService) =>
            {
                var newProduct = await productService.Create(request);
                return Results.Created($"api/Product/{newProduct.Id}", newProduct);
            });
            group.MapPut("/{id:Guid}", async (Guid id, ProductRequest request, IProductService productService) => {

                var product = await productService.Update(id, request);
                return Results.Ok(product);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IProductService productService) =>
            {
                var success = await productService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
