using FluentValidation;
using FluentValidation.Results;
using LPsalut.API.Application.NotaFiscal.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LPsalut.API.Application.NotaFiscal.Command
{
    public class CreateNotaFiscalCommand : IRequest<bool>
    {
        public string Produtos { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_total { get; set; }
        public string Cnpj { get; set; }
        public string N_cupom { get; set; }
        public string Canal_compra { get; set; }
        public DateTime Data_compra { get; set; }
        public string Img_nf { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; set; }

        public CreateNotaFiscalCommand(string produtos,int quantidade, decimal valor_total, string cnpj, string n_cupom, string canal_compra, DateTime data_compra, string img_nf)
        {
            Produtos = produtos;
            Quantidade = quantidade;
            Valor_total = valor_total;
            Cnpj = cnpj;
            N_cupom = n_cupom;
            Canal_compra = canal_compra;
            Data_compra = data_compra;
            Img_nf = img_nf;

            var validator = new CreateNotaFiscalCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
