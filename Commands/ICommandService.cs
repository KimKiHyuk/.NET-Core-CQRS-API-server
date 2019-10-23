using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Commands
{
    public interface ICommandService<T>
    {
        Task<T> SavePost(T dto);
    }
}