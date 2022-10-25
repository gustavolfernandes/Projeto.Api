namespace Projeto.Application
{
    public interface ICommand { }

    public interface ICommandHandler<in TRequest> where TRequest : ICommand
    {
        Task RunAsync(TRequest request);
    }
}
