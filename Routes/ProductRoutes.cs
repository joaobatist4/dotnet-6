using Dotnet6.Application;
using Dotnet6.Context;
using Dotnet6.DTO;
using Dotnet6.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.Routes;

public static class ProductRoutes
{
    public static WebApplication MapProductRoutes(this WebApplication app)
    {
        app.MapGet("/products", (ProductDbContext context) => context.Products?.ToList());

        app.MapPost("/products", 
            async (CreateProductRequest request, IMediator mediator)
                => await mediator.Send(request))
            .Produces<Product>(201);

        app.MapGet("/products/{id:Guid}", async (Guid id, ProductDbContext context)
            => await context.Products.FirstOrDefaultAsync(p => p.Id == id)
                is Product { Name: "jorge" } product
                    ? Results.Ok(product)
                    : Results.NotFound())
            .Produces<Product>(200)
            .Produces(404);

        app.MapDelete("/products/{id}", async (Guid id, ProductDbContext context) =>
        {
            if (await context.Products.FindAsync(id) is Product product)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return Results.Ok(product);
            }

            return Results.NotFound();
        });

        app.MapPut("/products/{id}", async (Guid id, ProductDTO inputProduct, ProductDbContext context) =>
        {
            if (await context.Products.FindAsync(id) is Product product)
            {
                product.Name = inputProduct.Name;
                product.Description = inputProduct.Description;

                context.Products.Update(product);
                await context.SaveChangesAsync();
                return Results.Ok(product);
            }

            return Results.NoContent();
        });

        return app;
    }
}

