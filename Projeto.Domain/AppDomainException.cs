namespace Projeto.Domain
{
    public class AppDomainException : Exception
    {
        public AppDomainException(string message) : base(message) { }
    }
}