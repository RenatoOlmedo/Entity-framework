using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPsalut.Domain
{
    public class NotaFiscal
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
