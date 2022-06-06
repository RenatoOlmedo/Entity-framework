using MediatR;
using LPsalut.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LPsalut.API.Application.Produto.Command;

namespace LPsalut.API.Application.Produto.Handler
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public UpdateProdutoCommandHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<bool> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            produto.Nome = request.Nome;
            produto.Preco = request.Preco;

            _produtoRepository.Update(produto);
            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
