using LPsalut.API.Application.NotaFiscal.Query;
using LPsalut.Domain;
using LPsalut.Infrastructure.Data.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LPsalut.API.Application.NotaFiscal.Handler
{
    public class GetAllNotaFiscalsQueryHandler : IRequestHandler<GetAllNotaFiscalsQuery, IEnumerable<Domain.NotaFiscal>>
    {
        private readonly IGenericRepository<Domain.NotaFiscal> _produtoRepository;

        public GetAllNotaFiscalsQueryHandler(IGenericRepository<Domain.NotaFiscal> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Domain.NotaFiscal>> Handle(GetAllNotaFiscalsQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
