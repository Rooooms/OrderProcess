using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;

namespace OrderProcess.App.Modules
{
    public static class CategoryModule
    {
        public static async void AddCategoryEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Category");

            group.MapGet("/", async (ICategoryService categoryService) => Results.Ok(await categoryService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ICategoryService categoryService) => {

                var category = await categoryService.GetById(id);

                if (category == null) return Results.NotFound();

                return Results.Ok(category);
            });


            group.MapPost("/", async (CategoryRequest request, ICategoryService categoryService) =>
            {
                var category = await categoryService.Create(request);
                return Results.Created($"api/Category/{category.Id}", category);
            });
            group.MapPut("/{id:Guid}", async (Guid id, CategoryRequest request, ICategoryService categoryService) => {

                var category = await categoryService.Update(id, request);
                return Results.Ok(category);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ICategoryService categoryService) =>
            {
                var success = await categoryService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });
        }
    }
}
