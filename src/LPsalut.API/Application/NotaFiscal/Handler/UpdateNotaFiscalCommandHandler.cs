using MediatR;
using LPsalut.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LPsalut.API.Application.NotaFiscal.Command;

namespace LPsalut.API.Application.NotaFiscal.Handler
{
    public class UpdateNotaFiscalCommandHandler : IRequestHandler<UpdateNotaFiscalCommand, bool>
    {
        private readonly IGenericRepository<Domain.NotaFiscal> _notaFiscalRepository;

        public UpdateNotaFiscalCommandHandler(IGenericRepository<Domain.NotaFiscal> produtoRepository)
        {
            _notaFiscalRepository = produtoRepository;
        }
        public async Task<bool> Handle(UpdateNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            var notaFiscal = await _notaFiscalRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            notaFiscal.Produtos = request.Produtos;
            notaFiscal.Quantidade = request.Quantidade;
            notaFiscal.Valor_total = request.Valor_total;
            notaFiscal.Cnpj = request.Cnpj;
            notaFiscal.N_cupom = request.N_cupom;
            notaFiscal.Canal_compra = request.Canal_compra;
            notaFiscal.Data_compra = request.Data_compra;
            notaFiscal.Img_nf = request.Img_nf;

            _notaFiscalRepository.Update(notaFiscal);
            return await _notaFiscalRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
