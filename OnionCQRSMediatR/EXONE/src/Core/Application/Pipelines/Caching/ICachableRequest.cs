﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipelines.Caching
{
    public interface ICachableRequest
    {
         string CacheKey { get; }
    }
}
