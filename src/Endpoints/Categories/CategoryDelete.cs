using Microsoft.AspNetCore.Mvc;
using OrderWebAPI.Infrastructure;

namespace OrderWebAPI.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, AppDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null)
        {
            return Results.NotFound();
        }

        context.Categories.Remove(category);
        context.SaveChanges();

        return Results.Ok($"Category {category.Id} removed");

    }
}
