using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LPsalut.API.Application.NotaFiscal.Command
{
    public class DeleteNotaFiscalCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
