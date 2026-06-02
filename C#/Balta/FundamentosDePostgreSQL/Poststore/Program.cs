using Microsoft.EntityFrameworkCore;
using Poststore.Data;
using Poststore.DTOs;
using Poststore.Models;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found");
builder.Services.AddDbContext<PoststroreDataContext>(x => x.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/v1/categories", async (PoststroreDataContext context, CreateCategoryRequest dto) => {

    var category = new Category {
        Heading = new Heading {
            Title = dto.Title,
            Slug = dto.Slug
        }
    };
    await context.Categories.AddAsync(category);
    await context.SaveChangesAsync();

    return Results.Created();
});

app.MapGet("/v1/categories", async (PoststroreDataContext context) => {

    var categories = await context
    .Categories
    .AsNoTracking()
    .ToListAsync();

    return Results.Ok(categories);
});

app.MapPost("/v1/products", async (PoststroreDataContext context, Product product) => {


    await context.Products.AddAsync(product);
    await context.SaveChangesAsync();

    return Results.Created();
});

app.MapGet("/v1/products", async (PoststroreDataContext context) => {

    var products = await context
        .Products
        .AsNoTracking()
        .ToListAsync();

    return Results.Ok(products);
});

app.Run();

