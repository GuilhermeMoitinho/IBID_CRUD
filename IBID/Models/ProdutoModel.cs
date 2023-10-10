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

        [Required(ErrorMessage = "Digite o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o valor do Preco!")]
        public string Preco { get; set; }

        [Required(ErrorMessage = "Digite a Data De Cadastro!")]
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
    }
}