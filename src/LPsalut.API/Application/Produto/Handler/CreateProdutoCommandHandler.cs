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
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public CreateProdutoCommandHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<bool> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var produto = new Domain.Produto
            {
                Nome = request.Nome,
                Preco = request.Preco
            };

            await _produtoRepository.AddAsync(produto, cancellationToken)
                .ConfigureAwait(false);

            return await _produtoRepository.CommitAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
