using LPsalut.API.Application.NotaFiscal.Command;
using LPsalut.Infrastructure.Data.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LPsalut.API.Application.NotaFiscal.Handler
{
    public class CreateNotaFiscalCommandHandler : IRequestHandler<CreateNotaFiscalCommand, bool>
    {
        private readonly IGenericRepository<Domain.NotaFiscal> _notaFiscalRepository;

        public CreateNotaFiscalCommandHandler(IGenericRepository<Domain.NotaFiscal> notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }
        public async Task<bool> Handle(CreateNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var notaFiscal = new Domain.NotaFiscal
            {
                Produtos = request.Produtos,
                Quantidade = request.Quantidade,
                Valor_total = request.Valor_total,
                Cnpj = request.Cnpj,
                N_cupom = request.N_cupom,
                Canal_compra = request.Canal_compra,
                Data_compra = request.Data_compra,
                Img_nf = request.Img_nf
        };

            await _notaFiscalRepository.AddAsync(notaFiscal, cancellationToken)
                .ConfigureAwait(false);

            return await _notaFiscalRepository.CommitAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
