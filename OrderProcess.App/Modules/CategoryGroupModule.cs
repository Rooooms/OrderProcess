using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class CategoryGroupModule
    {
        public static async void AddCategoryGroupEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/CategoryGroup");

            group.MapGet("/", async (ICategoryGroupService categoryGroupService) => Results.Ok(await categoryGroupService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ICategoryGroupService categoryGroupService) => {

                var categoryGroup = await categoryGroupService.GetById(id);

                if (categoryGroup == null) return Results.NotFound();

                return Results.Ok(categoryGroup);
            });

            group.MapGet("/groupno", async (int groupno, ICategoryGroupService categoryGroupService) => {

                var categoryGroup = await categoryGroupService.GetByGroupno(groupno);

                if (categoryGroup == null) return Results.NotFound();

                return Results.Ok(categoryGroup);
            });


            group.MapPost("/", async (CategoryGroupRequest request, ICategoryGroupService categoryGroupService) =>
            {
                var categoryGroup = await categoryGroupService.Create(request);
                return Results.Created($"api/CategoryGroup/{categoryGroup.Id}", categoryGroup);
            });
            group.MapPut("/{id:Guid}", async (Guid id, CategoryGroupRequest request, ICategoryGroupService categoryGroupService) => {

                var categoryGroup = await categoryGroupService.Update(id, request);
                return Results.Ok(categoryGroup);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ICategoryGroupService categoryGroupService) =>
            {
                var success = await categoryGroupService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
