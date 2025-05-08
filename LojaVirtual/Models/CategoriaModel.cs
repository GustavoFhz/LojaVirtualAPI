namespace LojaVirtual.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
