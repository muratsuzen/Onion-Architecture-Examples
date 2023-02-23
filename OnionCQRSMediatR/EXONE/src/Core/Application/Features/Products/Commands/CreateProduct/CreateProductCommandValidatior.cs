using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidatior : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidatior()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("En az 2 karakter giriniz");
        }
    }
}
