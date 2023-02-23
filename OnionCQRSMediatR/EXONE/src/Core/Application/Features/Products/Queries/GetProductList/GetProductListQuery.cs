﻿using Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<GetProductListDto>>
    {
       
    }
}
