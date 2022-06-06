using FluentValidation.Results;
using LPsalut.API.Application.Produto.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LPsalut.API.Application.Produto.Command
{
    public class CreateProdutoCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; set; }

        public CreateProdutoCommand(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;

            var validator = new CreateProdutoCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
