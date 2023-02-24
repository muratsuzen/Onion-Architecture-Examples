using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipelines.Caching
{
    public interface ICacheRemoveRequest
    {
        public string CacheKey { get;}
    }
}
