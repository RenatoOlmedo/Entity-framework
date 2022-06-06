using FluentValidation;
using LPsalut.API.Application.Produto.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPsalut.API.Application.Produto.Validation
{
    public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
    {
        public CreateProdutoCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(x => x.Preco)
                .NotNull()
                .NotEmpty();
        }
    }
}
