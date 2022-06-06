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
    public class DeleteNotaFiscalCommandHandler : IRequestHandler<DeleteNotaFiscalCommand, bool>
    {
        private readonly IGenericRepository<Domain.NotaFiscal> _notaFiscalRepository;

        public DeleteNotaFiscalCommandHandler(IGenericRepository<Domain.NotaFiscal> categoriaRepository)
        {
            _notaFiscalRepository = categoriaRepository;
        }
        public async Task<bool> Handle(DeleteNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            var notaFiscal = await _notaFiscalRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            _notaFiscalRepository.Delete(notaFiscal);

            return await _notaFiscalRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
