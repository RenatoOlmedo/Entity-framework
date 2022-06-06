using LPsalut.API.Application.Produto.Command;
using LPsalut.Infrastructure.Data.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LPsalut.API.Application.Produto.Handler
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public DeleteProdutoCommandHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<bool> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            _produtoRepository.Delete(produto);

            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
