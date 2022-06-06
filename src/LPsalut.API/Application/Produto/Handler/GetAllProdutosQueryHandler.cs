using LPsalut.API.Application.Produto.Query;
using LPsalut.Domain;
using LPsalut.Infrastructure.Data.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LPsalut.API.Application.Produto.Handler
{
    public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, IEnumerable<Domain.Produto>>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public GetAllProdutosQueryHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Domain.Produto>> Handle(GetAllProdutosQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
