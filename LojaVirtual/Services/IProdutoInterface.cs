using LojaVirtual.Dto;
using LojaVirtual.Models;

namespace LojaVirtual.Services
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<ProdutoModel>> RegistrarProduto(ProdutoDto produtoDto);
        Task<ResponseModel<List<ProdutoModel>>> ListarProdutos();
        Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int id);
        Task<ResponseModel<ProdutoModel>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto);
        Task<ResponseModel<ProdutoModel>> RemoverProduto(int id);

    }
}
