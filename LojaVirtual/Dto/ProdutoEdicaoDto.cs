using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Dto
{
    public class ProdutoEdicaoDto
    {
        [Required(ErrorMessage = "Informe o ID do produto")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int CategoriaId { get; set; }
    }
}
