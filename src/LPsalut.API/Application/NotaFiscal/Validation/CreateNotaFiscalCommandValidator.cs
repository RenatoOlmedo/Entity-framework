using FluentValidation;
using LPsalut.API.Application.NotaFiscal.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPsalut.API.Application.NotaFiscal.Validation
{
    public class CreateNotaFiscalCommandValidator : AbstractValidator<CreateNotaFiscalCommand>
    {
        public CreateNotaFiscalCommandValidator()
        {
            RuleFor(x => x.Produtos)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Quantidade)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(6);

            RuleFor(x => x.Valor_total)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cnpj)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.N_cupom)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Canal_compra)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Data_compra)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Img_nf)
                .NotNull()
                .NotEmpty();
        }
    }
}
