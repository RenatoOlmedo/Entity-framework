using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPsalut.API.Application.NotaFiscal.Query
{
    public class GetAllNotaFiscalsQuery : IRequest<IEnumerable<Domain.NotaFiscal>>
    {
    }
}
