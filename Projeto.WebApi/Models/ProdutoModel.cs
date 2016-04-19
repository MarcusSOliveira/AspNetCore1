using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //mapeamento..

namespace Projeto.WebApi.Models
{
    public class ProdutoModelCadastro
    {
        [Required(ErrorMessage = "Informe o Nome.")]
        [MinLength(3, ErrorMessage = "Nome deve ter no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Informe o Preço.")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Preco inválido.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantidade inválida.")]
        public int Quantidade { get; set; }
    }

    public class ProdutoModelEdicao
    {
        [Required(ErrorMessage = "Informe o Id do Produto.")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Informe o Nome.")]
        [MinLength(3, ErrorMessage = "Nome deve ter no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Preço.")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Preco inválido.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantidade inválida.")]
        public int Quantidade { get; set; }
    }

    public class ProdutoModelConsulta
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
