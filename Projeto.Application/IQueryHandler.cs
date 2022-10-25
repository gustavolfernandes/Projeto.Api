using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application
{
    public interface IQuery<out TResponse> { }

    public interface IQueryHandler<in TRequest, TResponse> where TRequest : IQuery<TResponse>
    {
        Task<TResponse> RunAsync(TRequest request);
    }
}
