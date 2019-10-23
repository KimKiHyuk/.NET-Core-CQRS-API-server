using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Queries
{
    interface IQueryService<T>
    {
        public Task<IEnumerable<T>> All();
    }
}