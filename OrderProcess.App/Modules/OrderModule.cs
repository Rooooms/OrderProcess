using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class OrderModule
    {
        public static async void AddOrderEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Order");

            group.MapGet("/", async (IOrderService orderService) => Results.Ok(await orderService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IOrderService orderService) => {

                var order = await orderService.GetById(id);

                if (order == null) return Results.NotFound();

                return Results.Ok(order);
            });


            group.MapPost("/", async (OrderRequest request, IOrderService orderService) =>
            {
                var newOrder = await orderService.Create(request);
                return Results.Created($"api/Order/", newOrder);
            });
            //group.MapPut("/{id:Guid}", async (Guid id, OrderRequest request, IOrderService orderService) => {

            //    var product = await orderService.Update(id, request);
            //    return Results.Ok(product);
            //});
            group.MapDelete("/{id:Guid}", async (Guid id, IOrderService orderService) =>
            {
                var success = await orderService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
