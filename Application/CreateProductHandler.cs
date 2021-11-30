using Dotnet6.Context;
using Dotnet6.Models;
using MediatR;

namespace Dotnet6.Application
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Product>
    {
        private readonly ProductDbContext _context;

        public CreateProductHandler(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
                .CreateProduct(request.Name, request.Description, 0);

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
