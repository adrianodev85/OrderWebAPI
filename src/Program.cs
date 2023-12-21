using OrderWebAPI.Endpoints.Categories;
using OrderWebAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionStrings:DataBase"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);

app.Run();
