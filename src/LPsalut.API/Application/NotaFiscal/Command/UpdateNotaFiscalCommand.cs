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
    public class UpdateNotaFiscalCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Produtos { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_total { get; set; }
        public string Cnpj { get; set; }
        public string N_cupom { get; set; }
        public string Canal_compra { get; set; }
        public DateTime Data_compra { get; set; }
        public string Img_nf { get; set; }
    }
}
