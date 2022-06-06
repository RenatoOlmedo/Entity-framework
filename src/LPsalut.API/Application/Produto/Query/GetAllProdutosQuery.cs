using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPsalut.API.Application.Produto.Query
{
    public class GetAllProdutosQuery : IRequest<IEnumerable<Domain.Produto>>
    {
    }
}
