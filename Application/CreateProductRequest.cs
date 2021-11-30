using Dotnet6.Models;
using MediatR;

namespace Dotnet6.Application
{
    public class CreateProductRequest : IRequest<Product>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
