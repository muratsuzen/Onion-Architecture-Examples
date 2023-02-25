using Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateCommand
{
    public class CreateProductCommand : IRequest<CreateProductDto>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
