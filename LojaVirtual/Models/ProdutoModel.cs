namespace LojaVirtual.Models
{
    public class ProdutoModel
    { 
            public int Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public decimal Preco { get; set; }
            public DateTime DataCadastro { get; set; } = DateTime.Now;
            public int CategoriaId { get; set; }
            public string ImagemUrl { get; set; } = string.Empty;
            public CategoriaModel Categoria { get; set; }
        

    }
}
