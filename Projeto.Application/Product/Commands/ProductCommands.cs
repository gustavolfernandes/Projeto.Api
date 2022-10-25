using Projeto.Domain;
using Projeto.Infra;

namespace Projeto.Application.Products;
public sealed class PostProductCommand : ICommand
{
    /// <example>336037D8-A93D-4401-8228-663E007DCBC4</example>
    public Guid Id { get; set; }

    /// <example>lorem ipsum</example>
    public string Name { get; set; } = default!;

    public void Deconstruct(out ProductId id, out string name)
    {
        id = Id.ToType<ProductId>();
        name = Name ?? throw new AppException("Product name can't be null");
    }
}

public sealed class PutProductCommand : ICommand
{
    /// <example>0DDD2EAC-CEFC-49A8-A61E-A6B0FF4F4382</example>
    public Guid Id { get; set; }

    /// <example>lorem ipsum</example>
    public string Name { get; set; } = default!;

    public void Deconstruct(out ProductId id, out string name)
    {
        id = Id.ToType<ProductId>();
        name = Name ?? throw new AppException("Product name can't be null");
    }
}

public sealed class DeleteProductCommand : ICommand
{
    public Guid Id { get; set; }
}