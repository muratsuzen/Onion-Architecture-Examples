using Application.Features.Products.Dtos;
using Application.Pipelines.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<GetProductListDto>>, ICachableRequest
    {
        public string CacheKey => $"Product";
    }
}
