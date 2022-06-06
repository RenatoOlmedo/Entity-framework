using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LPsalut.API.Application.Produto.Command
{
    public class DeleteProdutoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
