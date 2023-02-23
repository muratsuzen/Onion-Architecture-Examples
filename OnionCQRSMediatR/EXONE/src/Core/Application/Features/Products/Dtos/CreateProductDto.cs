using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Dtos
{
    public class CreateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
    }
}
