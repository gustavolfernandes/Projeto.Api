using FluentValidation;
using Projeto.Infra;


namespace Projeto.Application.Products
{
    [Injectable(typeof(IValidator<PostProductCommand>), LifeTime.Singleton)]
    public sealed class PostProductCommandValidator : AbstractValidator<PostProductCommand>
    {
        public PostProductCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Name).NotEmpty().MaximumLength(200);
        }
    }
    [Injectable(typeof(IValidator<PutProductCommand>), LifeTime.Singleton)]
    public sealed class PutProductCommandValidator : AbstractValidator<PostProductCommand>
    {
        public PutProductCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Name).NotEmpty().MaximumLength(200);
        }
    }
}
