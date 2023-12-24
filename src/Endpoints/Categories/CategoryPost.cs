using OrderWebAPI.Domain.Product;
using OrderWebAPI.Infrastructure;

namespace OrderWebAPI.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, AppDbContext context)
    {
        var category = new Category(categoryRequest.Name, "Adriano", "Adriano");

        if(!category.IsValid)
        {
            var errors = category.Notifications.GroupBy(e => e.Key)
                .ToDictionary(e => e.Key, e => e.Select(x => x.Message).ToArray());
            return Results.ValidationProblem(errors);
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}
