namespace LojaVirtual.Dto
{
    public class ProdutoUploadDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }

        // Aqui o usuário envia os arquivos (imagens)
        public ICollection<IFormFile> Imagens { get; set; } = new List<IFormFile>();
    }
}
