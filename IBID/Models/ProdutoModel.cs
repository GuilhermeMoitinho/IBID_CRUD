using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBID.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Preco { get; set; }
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
    }
}