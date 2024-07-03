using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;
using OrderProcess.Service.Services;

namespace OrderProcess.App.Modules
{
    public static class DealCodeModule
    {
        public static async void AddDealCodeModule(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/DealCode");

            group.MapGet("/", async (IDealCodeService dealCodeService) => Results.Ok(await dealCodeService.GetAll()));


            group.MapPost("/", async (DealCodeRequest request, IDealCodeService dealCodeService) =>
            {
                var dealcode = await dealCodeService.Create(request);
                return Results.Created($"api/DealCode/{dealcode.Id}", dealcode);
            });
            group.MapPut("/{id:Guid}", async (Guid id, DealCodeRequest request, IDealCodeService dealCodeService) => {

                var dealcode = await dealCodeService.Update(id, request);
                return Results.Ok(dealcode);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IDealCodeService dealCodeService) =>
            {
                var success = await dealCodeService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
